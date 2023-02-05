using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class CustoDAO : DAO
    {
        public static async Task<bool> Altera(string id, CustoModel custo)
        {
            try
            {
                List<CustoModel> custos = await RetornaLista(id);

                CustoModel custoAlterar = custos.Where(x => x.id_type.Equals(custo.id_type) && x.ano.Equals(custo.ano)).First();

                await Task.Run(() => custoAlterar.valor = custo.valor);
                await Task.Run(() => custoAlterar.last_update = DateTime.UtcNow);

                return true;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static async Task<bool> Existe(string id, string idType, short ano)
        {
            try
            {
                List<CustoModel> custos = await RetornaLista(id);

                return await Task.Run(() => custos.Any(x => x.id_type.Equals(idType) && x.ano.Equals(ano)));
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static async Task<bool> Insere(string id, CustoModel custo)
        {
            try
            {
                List<CustoModel> custos = await RetornaLista(id);

                await Task.Run(() => custos.Add(custo));

                EmpresaModel empresa = Empresas.Where(x => x.id.Equals(id)).First();

                empresa.custos = custos;

                return true;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static async Task<List<CustoModel>> RetornaLista(string id)
        {
            try
            {
                return await Task.Run(() => Empresas.Where(x => x.id.Equals(id)).SelectMany(x => x.custos).ToList() ?? new List<CustoModel>());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static async Task<List<CustoModel>> RetornaSomaCustos(int id)
        {
            try
            {
                List<string> idEmpresas = Grupos.Where(x => x.id.Equals(id)).SelectMany(x => x.companys).ToList();

                List<CustoModel> custos = new();
                List<CustoModel> custosSomados = new();

                for (int i = 0; i < idEmpresas.Count; i++)
                {
                    custos.AddRange(Empresas.Where(x => x.id.Equals(idEmpresas[i])).SelectMany(x => x.custos).ToList());
                }

                var x = from c in custos
                        group c by new { c.ano, c.id_type } into a
                        select new { a.Key.ano, a.Key.id_type, valor = a.Sum(c => c.valor) };

                foreach (var CustoModel in x)
                {
                    custosSomados.Add(new CustoModel
                    {
                        ano = CustoModel.ano,
                        id_type = CustoModel.id_type,
                        valor = CustoModel.valor,
                        last_update = DateTime.UtcNow
                    });
                }

                return await Task.Run(() => custosSomados);
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

    }
}
