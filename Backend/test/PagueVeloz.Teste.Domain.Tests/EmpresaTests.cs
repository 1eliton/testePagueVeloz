using System;
using System.Collections.Generic;
using Xunit;

namespace PagueVeloz.Teste.Domain.Tests
{
    public class EmpresaTests
    {

        [Fact]
        [Trait("Categoria", "Empresa testes")]
        public void Empresa_Criar_DeveExecutarComSucesso()
        {
            //Arrange
            Rg rg = "5.7123098089";
            Cnpj cnpj = "07.502130203";
            Documento doc = "1231232";
            DataNascimento dataNascimento = DateTime.Now.AddDays(-18).ToString();

            //Act
            var fornecedor = new Fornecedor("Fornecedor de teste", rg, dataNascimento, doc, DateTime.Now, new List<Telefone>());
            var empresa = new Empresa("Empresa do Éliton", cnpj, "SC", fornecedor);

            //Assert
            Assert.NotNull(fornecedor);
            Assert.NotNull(empresa);
        }

    }
}