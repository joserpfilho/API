using Model;
using FluentValidation;

namespace API.Validators
{
    public class EmpresaValidator : BaseValidator<EmpresaModel>
    {
        public EmpresaValidator()
        {
            Include(new DataValidator());

            RuleFor(x => x.id)
                .NotEmpty().WithMessage(ID_VAZIO)
                .Length(3, 10).WithMessage(TamanhoMinMax("id", 3, 10));

            RuleFor(x => x.status)
                .NotEmpty().WithMessage(STATUS_VAZIO)
                .Must(StatusValido).WithMessage(STATUS_INVALIDO);

            RuleFor(x => x.date_ingestion)
                .NotEmpty().WithMessage(DATA_CRIACAO_VAZIA)
                .Must(DataValida).WithMessage(DATA_CRIACAO_INVALIDA);
        }
    }
}
