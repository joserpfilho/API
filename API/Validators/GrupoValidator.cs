using Model;
using FluentValidation;

namespace API.Validators
{
    public class GrupoValidator : BaseValidator<GrupoModel>
    {
        public GrupoValidator()
        {
            Include(new DataValidator());

            RuleFor(x => x.id)
                .NotEmpty().WithMessage(ID_VAZIO)
                .GreaterThan(0).WithMessage(ID_INVALIDO);

            RuleFor(x => x.nome)
                .NotEmpty().WithMessage(NOME_VAZIO);

            RuleFor(x => x.category)
                .NotEmpty().WithMessage(CATEGORIA_VAZIA);

            RuleForEach(x => x.companys)
                .NotEmpty().WithMessage(EMPRESA_VAZIA);
        }
    }
}
