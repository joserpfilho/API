using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util;

namespace DAL
{
    public class EmpresaDAO : DAO
    {
        public static async Task<bool> Apaga(string id)
        {
            try
            {
                EmpresaModel empresa = Empresas.Where(x => x.id.Equals(id) && x.status == Funcoes.ATIVO).FirstOrDefault();

                await Task.Run(() => empresa.status = Funcoes.INATIVO);

                return true;
            }
            catch
            {
                return false; ;
            }
        }

        public static async Task<bool> Existe(string id)
        {
            try
            {
                return await Task.Run(() => Empresas.Any(x => x.id.Equals(id) && x.status == Funcoes.ATIVO));
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static async Task<bool> Insere(EmpresaModel empresa)
        {
            try
            {
                await Task.Run(() => Empresas.Add(empresa));

                return true;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static async Task<EmpresaModel> RetornaObjeto(string id)
        {
            try
            {
                return await Task.Run(() => Empresas.Where(x => x.id.Equals(id) && x.status == Funcoes.ATIVO).FirstOrDefault());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }
    }
}
