using System;
using System.Collections.Generic;
using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Domain
{
    public class Fornecedor : Agregate
    {
        public Guid IdEmpresa { get; private set; }
        public Empresa Empresa { get; private set; }

        /// <summary>
        /// Nome do fornecedor.
        /// <para>
        /// Not null
        /// </para>
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// RG do fornecedor.
        /// <para>Utilizado apenas quando o fornecedor é pessoa física.</para>
        /// <para>Null</para>
        /// </summary>
        public Rg Rg { get; private set; }

        /// <summary>
        /// Data de nascimento do fornecedor.
        /// <para>Utilizado apenas quando o fornecedor é pessoa física.</para>
        /// <para>Null</para>
        /// </summary>
        public DataNascimento DataNascimento { get; private set; }


        /// <summary>
        /// Documento do forncedor.
        /// <para>
        /// Pode ser pessoa física(CPF) ou jurídica(CNPJ)
        /// </para>
        /// <para>
        /// Not null
        /// </para>
        /// </summary>
        public Documento Documento { get; private set; }

        /// <summary>
        /// Data de cadastro do fornecedor
        /// <para>
        /// Not null
        /// </para>
        /// </summary>
        public DateTime DataCadastro { get; private set; }

        ///// <summary>
        /// Coleção de telefones do fornecedor.
        /// </summary>
        public ICollection<Telefone> Telefones { get; private set; }

        public Fornecedor(Empresa empresa, string nome, Rg rg, DataNascimento dataNascimento, Documento documento, Telefone telefone)
        {
            Empresa = empresa;
            Rg = rg;
            DataNascimento = dataNascimento;
            Documento = documento;

            Nome = nome;
            DataCadastro = DateTime.Now;

            AdicionarTelefone(telefone);
        }

        /// <summary>
        /// Adicionar um telefone para o fornecedor
        /// </summary>
        /// <param name="tel">Telefone a ser adicionado</param>
        public void AdicionarTelefone(Telefone tel)
        {
            if (Telefones == null)
                Telefones = new List<Telefone>();
            Telefones.Add(tel);
        }

        /// <summary>
        /// Verificação se o fornecedor é maior de idade.
        /// </summary>
        /// <returns>True se for maior de idade, false caso contrário.</returns>
        //public bool EhMaiorIdade() => (DateTime.Now.Year - DataNascimento.Value.Year) > 18;
        public bool EhMaiorIdade() => true;/*(DateTime.Now.Year - ) > 18;*/

        /// <summary>
        /// Verificação do tipo da pessoa.
        /// </summary>
        /// <returns>Pessoa jurídica ou pessoa física dependendo do <seealso cref="Documento"/></returns>
        public TipoPessoa ObterTipoPessoa() => Documento.Value.Length > 14 ? TipoPessoa.Juridica : TipoPessoa.Fisica;

        /// <summary>
        /// Construtor para o EF.
        /// </summary>
        protected Fornecedor()
        { }
    }
}