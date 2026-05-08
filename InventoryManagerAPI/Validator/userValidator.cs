using FluentValidation;
using FluentValidation.Results;
using InventoryManagerAPI.Models;
using InventoryManagerAPI.Services;
using static InventoryManagerAPI.Controller.InventoryController;
using static InventoryManagerAPI.Services.InventoryService;

namespace InventoryManagerAPI.Validator

{
    public class InventoryItemValidator : AbstractValidator<InventoryItem>
    {
        public InventoryItemValidator()
        { //Validador para criar item

            RuleFor(x => x.Name).NotEmpty().WithMessage("O campo nome é obrigatório!")
            .MaximumLength(400).MinimumLength(5).WithMessage("O número de caracteres é inválido!");

            RuleFor(x => x.Category).NotEmpty().WithMessage("O campo categoria é obrigatório")
            .MaximumLength(400).MinimumLength(5).WithMessage("O número de caracteres está incorreto");

            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0).WithMessage("O número não pode ser negativo")
            .LessThanOrEqualTo(999).WithMessage("O número não pode ser maior que 999!");

        }
        public class AddItemRequestValidator : AbstractValidator<ItemRequest>
        { //Segundo validador para adicionar item.
            public AddItemRequestValidator()
            {
                RuleFor(x => x.Quantity)
                    .GreaterThan(0)
                    .WithMessage("A quantidade deve ser maior que zero.")
                    .LessThanOrEqualTo(999)
                    .WithMessage("A quantidade não pode ser maior que 999.");
            }
        }
        public class RemoveStockRequestValidator
        : AbstractValidator<RemoveStockRequest>
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
}
