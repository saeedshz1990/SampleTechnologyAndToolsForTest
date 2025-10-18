using MediatR;
using SampleForTest.Common;
using System.Runtime.CompilerServices;

namespace Command.Application.Articles.Dto.Create
{
    public class CreateArticleCommand : IRequest<ResultDto<long>>
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Tag { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long ArticleCategoryId { get; set; }
    }
}
