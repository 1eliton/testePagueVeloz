using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using PagueVeloz.Teste.Domain.Core;
using PagueVeloz.Teste.Domain.Exceptions;

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
        public Rg? Rg { get; private set; }

        /// <summary>
        /// Data de nascimento do fornecedor.
        /// <para>Utilizado apenas quando o fornecedor é pessoa física.</para>
        /// <para>Null</para>
        /// </summary>
        public DataNascimento? DataNascimento { get; private set; }

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

        /// <summary>
        /// Coleção de telefones do fornecedor.
        /// </summary>
        public ICollection<Telefone> Telefones { get; private set; }

        public Fornecedor(Guid idEmpresa, Empresa empresa, string nome, Rg rg, DataNascimento dataNascimento, Documento documento, DateTime dataCadastro, ICollection<Telefone> telefones)
        {
            IdEmpresa = idEmpresa;
            Empresa = empresa;
            Nome = nome;
            Rg = rg;
            DataNascimento = dataNascimento;
            Documento = documento;
            DataCadastro = dataCadastro;
            Telefones = telefones;
            
        }
    }
}