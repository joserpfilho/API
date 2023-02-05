using DAL;
using Model;
using System.Threading.Tasks;

namespace BLL
{
    public static class EmpresaBO
    {
        public static async Task<bool> Apaga(string id)
        {
            return await EmpresaDAO.Apaga(id);
        }

        public static async Task<bool> Existe(string id)
        {
            return await EmpresaDAO.Existe(id);
        }

        public static async Task<bool> Insere(EmpresaModel empresa)
        {
            if (empresa.custos == null)
                empresa.custos = new();

            return await EmpresaDAO.Insere(empresa);
        }

        public static async Task<EmpresaModel> RetornaObjeto(string id)
        {
            return await EmpresaDAO.RetornaObjeto(id);
        }
    }
}
