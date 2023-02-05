using API.Validators;
using BLL;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Util;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GrupoController : BaseController
    {
        [HttpGet("{data}")]
        [Authorize]
        public async Task<ActionResult<List<GrupoModel>>> RetornaLista(string data)
        {
            try
            {
                if (await GrupoBO.Existe(data))
                    return Ok(await GrupoBO.RetornaLista(data));

                else
                    return NaoEncontrado(Funcoes.OBJETO_GRUPO);
            }
            catch
            {
                return Erro();
            }
        }

        [HttpGet("_{id}")]
        [Authorize]
        public async Task<ActionResult<GrupoModel>> RetornaObjeto(int id)
        {
            try
            {
                if (await GrupoBO.Existe(id))
                    return Ok(await GrupoBO.RetornaObjeto(id));

                else
                    return NaoEncontrado(Funcoes.OBJETO_GRUPO);
            }
            catch
            {
                return Erro();
            }
        }

        [HttpGet("custos/_{id}")]
        [Authorize]
        public async Task<ActionResult<List<CustoModel>>> RetornaCustosGrupo(int id)
        {
            try
            {
                if (await GrupoBO.Existe(id))
                {
                    return Ok(await CustoBO.RetornaSomaCustos(id));
                }
                else
                    return NaoEncontrado(Funcoes.OBJETO_GRUPO);
            }
            catch
            {
                return Erro();
            }
        }

        [HttpPost]
        [Authorize(Roles = Funcoes.ADMIN)]
        public async Task<ActionResult> Insere([FromBody] GrupoModel grupo)
        {
            try
            {
                GrupoValidator validador = new();
                ValidationResult resultadoValidacao = validador.Validate(grupo);

                if (resultadoValidacao.IsValid)
                {
                    if (await GrupoBO.Existe(grupo.id))
                        return JaExiste(Funcoes.OBJETO_GRUPO);

                    else
                    {
                        if (await GrupoBO.Insere(grupo))
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
                return Erro();
            }
        }

        [HttpPut("_{id}")]
        [Authorize(Roles = Funcoes.ADMIN)]
        public async Task<ActionResult> Altera([FromBody] string id_empresa, int id)
        {
            try
            {
                if (await GrupoBO.Existe(id))
                {
                    if (await EmpresaBO.Existe(id_empresa))
                    {
                        if (await GrupoBO.AdicionarEmpresa(id, id_empresa))
                            return CadastroEfetuado();

                        else
                            return NaoFoiPossivel();
                    }
                    else
                        return NaoEncontrado(Funcoes.OBJETO_EMPRESA);
                }
                else
                    return NaoEncontrado(Funcoes.OBJETO_GRUPO);
            }
            catch
            {
                return Erro();
            }
        }
    }
}
