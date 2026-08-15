using Command.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Query.Application.Products.QueryResult;
using Query.Persistence.Common;
using SampleTechnologyForTest.Entities.Events.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SampleTechnologyForTest.Infrastructure.BackgroundServices
{
    public class OutboxProcessorService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<OutboxProcessorService> _logger;

        public OutboxProcessorService(
            IServiceScopeFactory scopeFactory,
            ILogger<OutboxProcessorService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(
            CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();

                    var commandContext =
                        scope.ServiceProvider.GetRequiredService<SampleCommandContext>();

                    var queryContext =
                        scope.ServiceProvider.GetRequiredService<SampleQueryContext>();

                    var messages = await commandContext.OutboxMessages
                        .Where(x => x.ProcessedAtUtc == null)
                        .OrderBy(x => x.CreatedAtUtc)
                        .Take(20)
                        .ToListAsync(stoppingToken);

                    foreach (var message in messages)
                    {
                        try
                        {
                            if (message.Type == nameof(ProductCreatedEvent))
                            {
                                var productCreated =
                                    JsonSerializer.Deserialize<ProductCreatedEvent>(
                                        message.Payload);

                                if (productCreated is null)
                                    throw new InvalidOperationException(
                                        "ProductCreatedEvent payload is invalid.");

                                var exists = await queryContext.Products
                                    .AnyAsync(
                                        x => x.Id == productCreated.ProductId,
                                        stoppingToken);

                                if (!exists)
                                {
                                    var product = new ProductQr
                                    {
                                        Id = productCreated.ProductId,
                                        Title = productCreated.Title,
                                        Description = productCreated.Description,
                                        CategoryId = productCreated.CategoryId
                                    };

                                    await queryContext.Products.AddAsync(
                                        product,
                                        stoppingToken);

                                    await queryContext.SaveChangesAsync(stoppingToken);
                                }
                            }

                            message.ProcessedAtUtc = DateTime.UtcNow;
                            message.Error = null;

                            await commandContext.SaveChangesAsync(stoppingToken);
                        }
                        catch (Exception ex)
                        {
                            message.Error = ex.Message;

                            await commandContext.SaveChangesAsync(stoppingToken);

                            _logger.LogError(
                                ex,
                                "Error processing outbox message {MessageId}",
                                message.Id);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        ex,
                        "Error executing outbox processor");
                }

                await Task.Delay(
                    TimeSpan.FromSeconds(5),
                    stoppingToken);
            }
        }
    }
}