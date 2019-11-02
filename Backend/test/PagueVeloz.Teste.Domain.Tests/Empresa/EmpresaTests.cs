using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using PagueVeloz.Teste.Domain.Tests;
using Xunit;

namespace PagueVeloz.Teste.Domain
{
    [Collection(nameof(EmpresaTestsCollection))]
    public class EmpresaTests
    {
        private readonly EmpresaFixturesTests _empresaFixturesTests;
        public EmpresaTests(EmpresaFixturesTests empresaFixturesTests)
        {
            _empresaFixturesTests = empresaFixturesTests;
        }


        [Fact]
        [Trait("Categoria", "Empresa testes")]
        public void Empresa_Criar_DeveExecutarComSucesso()
        {
            //Arrange && Act
            var empresa = _empresaFixturesTests.ObterEmpresaValida().FirstOrDefault();

            //Assert
            empresa.Should().NotBeNull("A empresa gerada é válida");
            empresa.Fornecedores.Should().BeNull("Construtor não espera um fornecedor");
        }

    }
}