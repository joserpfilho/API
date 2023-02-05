using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    public class BaseController : ControllerBase
    {
        #region Constantes
        protected const string ALTERACAO_REALIZADA = "Alteracao realizada no sistema.";
        protected const string APAGADO = "apagado(a).";
        protected const string NAO_ENCONTRADO = "nao encontrado(a) no sistema.";
        protected const string OCORREU_ERRO = "Ocorreu um erro no sistema, tente novamente mais tarde.";
        protected const string CADASTRO_EFETUADO = "Cadastro efetuado com sucesso!";
        protected const string JA_EXISTE = "ja existe no sistema";

        #endregion Constantes

        #region Retornos

        protected ActionResult AlteracaoRealizada()
        {
            return Ok(new RetornoAPIModel()
            {
                Mensagem = ALTERACAO_REALIZADA
            });
        }

        protected ActionResult Apagado(string objeto)
        {
            return Ok(new RetornoAPIModel()
            {
                Mensagem = $"{objeto} {APAGADO}"
            });
        }

        protected ActionResult CadastroEfetuado()
        {
            return Ok(new RetornoAPIModel()
            {
                Mensagem = CADASTRO_EFETUADO
            });
        }

        protected ActionResult Erro()
        {
            return StatusCode(500);
        }

        protected ActionResult Invalido(string validacoes)
        {
            return BadRequest(new RetornoAPIModel()
            {
                Mensagem = validacoes
            });
        }

        protected ActionResult JaExiste(string objeto)
        {
            return Conflict(new RetornoAPIModel()
            {
                Mensagem = $"{objeto} {JA_EXISTE}"
            });
        }

        protected ActionResult NaoEncontrado(string objeto)
        {
            return NotFound(new RetornoAPIModel()
            {
                Mensagem = $"{objeto} {NAO_ENCONTRADO}"
            });
        }

        protected ActionResult NaoFoiPossivel()
        {
            return BadRequest(new RetornoAPIModel()
            {
                Mensagem = OCORREU_ERRO
            });
        }

        #endregion Retornos
    }
}
