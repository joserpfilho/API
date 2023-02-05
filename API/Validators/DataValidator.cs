using System;
using FluentValidation;
using Model;

namespace API.Validators
{
    public class DataValidator : BaseValidator<BaseModel>
    {
        public DataValidator()
        {
            RuleFor(x => x.date_ingestion)
                .Must(FormatoDataValida).WithMessage(DATA_INVALIDA)
                .Must(DataValida).WithMessage(DATA_CRIACAO_INVALIDA);
        }
    }
}
