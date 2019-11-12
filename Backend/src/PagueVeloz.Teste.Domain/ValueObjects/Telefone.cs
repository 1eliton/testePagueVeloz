using System;
using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Domain
{
    public class Telefone : Agregate
    {
        public Guid IdFornecedor { get; private set; }
        public Fornecedor Fornecedor { get; private set; }
        public string Numero { get; private set; }

        public Telefone(string numero)
        {
            Numero = numero;
        }

        /// <summary>
        /// EF
        /// </summary>
        protected Telefone()
        { }
    }
}