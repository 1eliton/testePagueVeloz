using System;
using System.Collections.Generic;

namespace PagueVeloz.Teste.Domain
{
    public class Empresa : AgregateRoot
    {
        /// <summary>
        /// Nome fantasia da empresa.
        /// <para>
        /// Not null
        /// </para>
        /// </summary>
        public string NomeFantasia { get; private set; }

        /// <summary>
        /// Cnpj da empresa.
        /// <para>
        /// Not null
        /// </para>
        /// </summary>
        public Cnpj Cnpj { get; private set; }

        /// <summary>
        /// Unidade federativa da empresa.
        /// <para>
        /// Not null
        /// </para>
        /// </summary>
        public string Uf { get; private set; }

        /// <summary>
        /// Fornecedores vinculados a empresa.
        /// </summary>
        public ICollection<Fornecedor> Fornecedores { get; private set; }

        /// <summary>
        /// Construtor para a empresa. Não efetuará a vinculação do fornecedor com a empresa.
        /// </summary>
        /// <param name="nomeFantasia">Nome fantasia da empresa.</param>
        /// <param name="cnpj">Cnpj da empresa.</param>
        /// <param name="uf">Unidade Federativa da empresa</param>
        public Empresa(string nomeFantasia, Cnpj cnpj, string uf)
        {
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Uf = uf;
        }

        /// <summary>
        /// Construtor para empresa, com a opção de já vincular um fornecedor à empresa.
        /// </summary>
        /// <param name="nomeFantasia">Nome fantasia da empresa.</param>
        /// <param name="cnpj">Cnpj da empresa.</param>
        /// <param name="uf">Unidade Federativa da empresa</param>
        /// <param name="fornecedor">Fornecedor que será vinculado à empresa.</param>
        public Empresa(string nomeFantasia, Cnpj cnpj, string uf, Fornecedor fornecedor)
        {
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Uf = uf;

            VincularFornecedor(fornecedor);
        }

        /// <summary>
        /// Efetua a vinculação de um fornecedor à uma empresa.
        /// </summary>
        /// <param name="fornecedor"></param>
        public void VincularFornecedor(Fornecedor fornecedor)
        {
            if (Fornecedores == null)
                Fornecedores = new List<Fornecedor>();

            Fornecedores.Add(fornecedor);
        }

        /// <summary>
        /// Construtor EF.
        /// </summary>
        protected Empresa() { }
    }
}