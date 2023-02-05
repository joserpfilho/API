using Model;
using System.Collections.Generic;

namespace DAL
{
    public class DAO
    {
        public readonly static List<EmpresaModel> Empresas = new();
        public readonly static List<GrupoModel> Grupos = new();
        public readonly static List<UsuarioModel> Usuarios = new();
    }
}
