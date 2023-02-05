using API.Validators;
using BLL;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Threading.Tasks;
using Util;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : BaseController
    {
        [HttpGet("_{id}")]
        [Authorize]
        public async Task<ActionResult<EmpresaModel>> RetornaObjeto(string id)
        {
            try
            {
                if (await EmpresaBO.Existe(id))
                    return Ok(await EmpresaBO.RetornaObjeto(id));

                else
                    return NaoEncontrado(Funcoes.OBJETO_EMPRESA);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Authorize(Roles = Funcoes.ADMIN)]
        public async Task<ActionResult<RetornoAPIModel>> Insere([FromBody] EmpresaModel empresa)
        {
            try
            {
                EmpresaValidator validador = new();
                ValidationResult resultadoValidacao = validador.Validate(empresa);

                if (resultadoValidacao.IsValid)
                {
                    if (await EmpresaBO.Existe(empresa.id))
                        return JaExiste(Funcoes.OBJETO_EMPRESA);

                    else
                    {
                        if (await EmpresaBO.Insere(empresa))
                            return CadastroEfetuado();

                        else
                            return NaoFoiPossivel();
                    }
                }
                else
                    return Invalido(resultadoValidacao.ToString());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("custos/_{id}")]
        [Authorize(Roles = Funcoes.ADMIN)]

        public async Task<ActionResult> InsereCusto([FromBody] CustoModel custo, string id)
        {
            try
            {
                CustoValidator validador = new();
                ValidationResult resultadoValidacao = validador.Validate(custo);

                if (resultadoValidacao.IsValid)
                {
                    if (await EmpresaBO.Existe(id))
                    {
                        if (await CustoBO.Existe(id, custo.id_type, custo.ano))
                        {
                            if (await CustoBO.Altera(id, custo))
                                return AlteracaoRealizada();

                            else
                                return NaoFoiPossivel();
                        }
                        else
                        {
                            if (await CustoBO.Insere(id, custo))
                                return CadastroEfetuado();

                            else
                                return NaoFoiPossivel();
                        }
                    }
                    else
                        return NaoEncontrado(Funcoes.OBJETO_EMPRESA);
                }
                else
                    return Invalido(resultadoValidacao.ToString());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("_{id}")]
        [Authorize(Roles = Funcoes.ADMIN)]
        public async Task<ActionResult> Apaga(string id)
        {
            try
            {
                if (await EmpresaBO.Existe(id))
                {
                    if (await EmpresaBO.Apaga(id))
                        return Apagado(Funcoes.OBJETO_EMPRESA);

                    else
                        return NaoFoiPossivel();
                }
                else
                    return NaoEncontrado(Funcoes.OBJETO_EMPRESA);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
