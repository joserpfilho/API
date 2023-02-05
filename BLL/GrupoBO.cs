using DAL;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public static class GrupoBO
    {
        public static async Task<bool> AdicionarEmpresa(int id, string id_empresa)
        {
            return await GrupoDAO.AdicionarEmpresa(id, id_empresa);
        }

        public static async Task<bool> Existe(int id)
        {
            return await GrupoDAO.Existe(id);
        }

        public static async Task<bool> Existe(string data)
        {
            return await GrupoDAO.Existe(data);
        }

        public static async Task<bool> Insere(GrupoModel grupo)
        {
            return await GrupoDAO.Insere(grupo);
        }

        public static async Task<List<GrupoModel>> RetornaLista(string data)
        {
            return await GrupoDAO.RetornaLista(data);
        }

        public static async Task<GrupoModel> RetornaObjeto(int id)
        {
            return await GrupoDAO.RetornaObjeto(id);
        }
    }
}
