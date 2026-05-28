using FluentValidation;
using InventoryManagerAPI.Services;
using static InventoryManagerAPI.Controller.InventoryController;

namespace InventoryManagerAPI.Validator
{
    public class RemoveStockRequestValidator : AbstractValidator<RemoveStockRequest>
    {
        private readonly InventoryService _service;

        public RemoveStockRequestValidator(InventoryService service)
        {
            _service = service;

            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("A quantidade deve ser maior que zero.")
                .LessThanOrEqualTo(999)
                .WithMessage("A quantidade não pode ser maior que 999.")
                .Must((request, quantity) =>
                {
                    var item = _service.GetById(request.ItemId);

                    return item != null &&
                           quantity <= item.Quantity;
                })
                .WithMessage("Quantidade indisponível em estoque.");
        }
    }
}
