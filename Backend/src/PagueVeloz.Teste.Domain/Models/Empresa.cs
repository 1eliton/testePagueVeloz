using System;
using System.Collections.Generic;
using PagueVeloz.Teste.Domain.Exceptions;

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
        /// <exception cref="DomainException">Quando o domínio é inválido.</exception>
        public Empresa(string nomeFantasia, Cnpj cnpj, string uf)
        {
            if (!cnpj.EhValido) throw new DomainException("É necessário um CNPJ válido.");
            NomeFantasia = nomeFantasia;
            Cnpj = cnpj;
            Uf = uf;
        }

        /// <summary>
        /// Efetua a vinculação de um fornecedor à uma empresa.
        /// </summary>
        /// <param name="fornecedor"></param>
        public void VincularFornecedor(Fornecedor fornecedor)
        {
            ValidarFornecedor(fornecedor);

            if (Fornecedores == null)
                Fornecedores = new List<Fornecedor>();

            Fornecedores.Add(fornecedor);
        }

        /// <summary>
        /// Efetua validações necessárias para um fornecedor ser atribuído à essa empresa.
        /// </summary>
        /// <param name="f">Fornecedor que será validado.</param>
        /// <exception cref="DomainException">Caso alguma regra de negócio do fornecedor esteja inválida.</exception>
        private void ValidarFornecedor(Fornecedor f)
        {
            /*
             Caso a empresa seja do Paraná, não permitir cadastrar um fornecedor pessoa física menor de idade;
               Caso o fornecedor seja pessoa física, também é necessário cadastrar o RG e a data de nascimento;
             */

            if (Uf == "PR" && f.ObterTipoPessoa() == TipoPessoa.Fisica && !f.EhMaiorIdade())
                throw new DomainException("Fornecedores do PARANÁ devem ser maiores de idade");

            if (f.ObterTipoPessoa() == TipoPessoa.Fisica)
            {
                if (f.Rg == null) throw new DomainException("O fornecedor pessoa física necessita de um RG para ser cadastrado.");

                if (f.DataNascimento == null) throw new DomainException("O fornecedor pessoa física necessita de uma data de nascimento para ser cadastrado.");
            }
        }

        /// <summary>
        /// Construtor EF.
        /// </summary>
        protected Empresa() { }
    }
}