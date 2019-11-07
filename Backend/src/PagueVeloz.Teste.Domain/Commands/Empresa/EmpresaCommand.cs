using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Domain.Commands.Empresa
{
    public class EmpresaCommand : Command
    {
        public string NomeFantasia { get; set; }
        public Cnpj Cnpj { get; set; }
        public string Uf { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}