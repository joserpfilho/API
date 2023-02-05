using FluentValidation;
using System;
using System.Globalization;
using Util;

namespace API.Validators
{
    public class BaseValidator<T> : AbstractValidator<T>
    {
        #region Constantes

        protected readonly string ANO_INVALIDO = "O ano deve ser a partir de 2000.";
        protected readonly string ANO_VAZIO = "Ano eh obrigatorio.";
        protected readonly string CATEGORIA_VAZIA = "Categoria eh obrigatoria.";
        protected readonly string DATA_CRIACAO_VAZIA = "Data de criacao do pedido eh obrigatoria.";
        protected readonly string DATA_CRIACAO_INVALIDA = "Data de criacao nao pode ser futura.";
        protected readonly string DATA_INVALIDA = "A data deve possuir o formato 'yyyy-MM-dd HH:mm'.";
        protected readonly string EMPRESA_VAZIA = "Id das empresas sao obrigatorias.";
        protected readonly string ID_INVALIDO = "Id deve ser um numero inteiro nao negativo.";
        protected readonly string ID_VAZIO = "Id eh obrigatorio.";
        protected readonly string ID_TYPE_VAZIO = "Id_type eh obrigatorio.";
        protected readonly string NOME_VAZIO = "Nome eh obrigatorio.";
        protected readonly string SENHA_VAZIA = "Senha eh obrigatoria.";
        protected readonly string STATUS_VAZIO = "Status eh obrigatorio.";
        protected readonly string STATUS_INVALIDO = "Status somente pode aceitar 'ATIVO' ou 'INATIVO'.";
        protected readonly string USUARIO_VAZIO = "Usuario eh obrigatorio.";
        protected readonly string VALOR_INVALIDO = "Valor deve ser maior que 0.";
        protected readonly string VALOR_VAZIO = "Valor eh obrigatorio.";

        #endregion Constantes

        #region Metodos

        protected static bool AnoValido(short ano)
        {
            return ano.ToString().Length == 4 && ano >= 2000;
        }

        protected static string TamanhoMinMax(string campo, short min, short max)
        {
            return $"{campo} deve conter entre {min} e {max} caracteres!";
        }

        protected static bool StatusValido(string status)
        {
            return status.ToUpper().Equals(Funcoes.ATIVO) || status.ToUpper().Equals(Funcoes.INATIVO);
        }

        protected static bool DataValida(string data)
        {
            return Convert.ToDateTime(data) <= DateTime.UtcNow;
        }

        protected static bool FormatoDataValida(string data)
        {
            return DateTime.TryParseExact(data, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        #endregion Metodos
    }
}
