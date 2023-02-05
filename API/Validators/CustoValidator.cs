using Model;
using FluentValidation;

namespace API.Validators
{
    public class CustoValidator : BaseValidator<CustoModel>
    {
        public CustoValidator()
        {
            RuleFor(x => x.ano)
                .NotEmpty().WithMessage(ANO_VAZIO)
                .Must(AnoValido).WithMessage(ANO_INVALIDO);

            RuleFor(x => x.id_type)
                .NotEmpty().WithMessage(ID_TYPE_VAZIO);

            RuleFor(x => x.valor)
                .NotEmpty().WithMessage(VALOR_VAZIO)
                .GreaterThan(0).WithMessage(VALOR_INVALIDO);
        }
    }
}
