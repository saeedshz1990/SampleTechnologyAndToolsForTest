using Command.Application.Orders.Dto.Update;
using Command.Application.Orders.Dto.UpdateOrderItem;
using FluentValidation;

namespace Command.Application.Orders.Service.UpdateOrderItem
{
    public class UpdateOrderItemCommandValidator : AbstractValidator<UpdateOrderItemCommand>
    {
        public UpdateOrderItemCommandValidator()
        {
        }
    }
}
