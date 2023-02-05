using DAL;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class CustoBO
    {
        public static async Task<bool> Existe(string id, string id_type, short ano)
        {
            return await CustoDAO.Existe(id, id_type, ano);
        }

        public static async Task<bool> Insere(string id, CustoModel custo)
        {
            return await CustoDAO.Insere(id, custo);
        }

        public static async Task<bool> Altera(string id, CustoModel custo)
        {
            return await CustoDAO.Altera(id, custo);
        }

        public static async Task<List<CustoModel>> RetornaSomaCustos(int id)
        {
            return await CustoDAO.RetornaSomaCustos(id);
        }
    }
}
