using DAL;
using Model;
using System.Threading.Tasks;

namespace BLL
{
    public static class UsuarioBO
    {
        public static async Task<UsuarioModel> Retorna(UsuarioModel usuario)
        {
            return await UsuarioDAO.Retorna(usuario);
        }
    }
}
