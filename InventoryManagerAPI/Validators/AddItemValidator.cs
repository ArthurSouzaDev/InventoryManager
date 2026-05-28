using FluentValidation;
using InventoryManagerAPI.Models;

namespace InventoryManagerAPI.Validator
{
    public class AddItemRequestValidator : AbstractValidator<InventoryItem>
    {//Segundo validador para adicionar item.
        public AddItemRequestValidator()
        {
            RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("A quantidade deve ser maior que zero.")
                .LessThanOrEqualTo(999)
                .WithMessage("A quantidade não pode ser maior que 999.");
        }


    }
}
