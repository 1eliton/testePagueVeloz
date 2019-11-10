using System;

namespace PagueVeloz.Teste.Application
{
    public class CadastrarFornecedorDto
    {
        public Guid IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Documento { get; set; }
        public string Telefone { get; set; }
    }
}