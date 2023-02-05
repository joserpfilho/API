using Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util;

namespace DAL
{
    public static class UsuarioDAO
    {
        public static async Task<UsuarioModel> Retorna(UsuarioModel usuario)
        {
            List<UsuarioModel> usuarios = new()
            {
                new() { id = 1, usuario = "admin", senha = "admin", acesso = Funcoes.ADMIN },
                new() { id = 2, usuario = "comum", senha = "comum", acesso = Funcoes.COMUM }
            };

            return await Task.Run(() => usuarios.Where(x => x.usuario.ToLower().Equals(usuario.usuario.ToLower())
                                 && x.senha.Equals(usuario.senha)).FirstOrDefault());
        }
    }
}
