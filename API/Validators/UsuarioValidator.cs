using Model;
using FluentValidation;

namespace API.Validators
{
    public class UsuarioValidator : BaseValidator<UsuarioModel>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.usuario)
                .NotEmpty().WithMessage(USUARIO_VAZIO);

            RuleFor(x => x.senha)
                .NotEmpty().WithMessage(SENHA_VAZIA);
        }
    }
}
