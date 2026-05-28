using FluentValidation;
using InventoryManagerAPI.Models;

namespace InventoryManagerAPI.Validator
{
    public class CreateItemValidator : AbstractValidator<InventoryItem>
    {
        public CreateItemValidator()
        { //Validador para criar item

            RuleFor(x => x.Name).NotEmpty()
            .WithMessage("O campo nome é obrigatório!")
            .MaximumLength(400)
            .MinimumLength(5)
            .WithMessage("O número de caracteres é inválido!");

            RuleFor(x => x.Category).NotEmpty()
            .WithMessage("O campo categoria é obrigatório")
            .MaximumLength(400)
            .MinimumLength(5)
            .WithMessage("O número de caracteres está incorreto");

            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0)
            .WithMessage("O número não pode ser negativo")
            .LessThanOrEqualTo(999)
            .WithMessage("O número não pode ser maior que 999!");

        }
    }
}
