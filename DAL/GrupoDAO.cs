using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class GrupoDAO : DAO
    {
        public static async Task<bool> AdicionarEmpresa(int id, string id_empresa)
        {
            try
            {
                await Task.Run(() => Grupos.Where(x => x.id.Equals(id)).Select(x => { x.companys.Add(id_empresa); return true; }));

                return true;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static async Task<bool> Existe(int id)
        {
            try
            {
                return await Task.Run(() => Grupos.Any(x => x.id.Equals(id)));
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static async Task<bool> Existe(string data)
        {
            try
            {
                return await Task.Run(() => Grupos.Any(x => Convert.ToDateTime(x.date_ingestion) <= Convert.ToDateTime(data)));
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static async Task<bool> Insere(GrupoModel grupo)
        {
            try
            {
                await Task.Run(() => Grupos.Add(grupo));

                return true;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static async Task<GrupoModel> RetornaObjeto(int id)
        {
            try
            {
                return await Task.Run(() => Grupos.Where(x => x.id.Equals(id)).First());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static async Task<List<GrupoModel>> RetornaLista(string data)
        {
            try
            {
                return await Task.Run(() => Grupos.Where(x => Convert.ToDateTime(x.date_ingestion) <= Convert.ToDateTime(data)).ToList());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
    }
}
