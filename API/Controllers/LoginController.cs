using API.Services;
using API.Validators;
using BLL;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Threading.Tasks;
using Util;

namespace API.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class LoginController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> Autenticar([FromBody] UsuarioModel usuario)
        {
            try
            {
                UsuarioValidator validador = new();
                ValidationResult resultadoValidacao = validador.Validate(usuario);

                if (resultadoValidacao.IsValid)
                {
                    UsuarioModel usuarioBase = await UsuarioBO.Retorna(usuario);

                    if (usuarioBase == null)
                        return NaoEncontrado(Funcoes.OBJETO_USUARIO);

                    else
                    {
                        var token = TokenService.GerarToken(usuarioBase);
                        usuario.senha = string.Empty;

                        return Ok(new
                        {
                            Token = token
                        });
                    }
                }
                else
                    return Invalido(resultadoValidacao.ToString());
            }
            catch (Exception e)
            {
                return Erro();
            }
        }
    }
}
