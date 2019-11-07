using PagueVeloz.Teste.Domain;

namespace PagueVeloz.Teste.Application.DTOs
{
    public class CadastrarEmpresaDto
    {
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Uf { get; set; }
    }
}