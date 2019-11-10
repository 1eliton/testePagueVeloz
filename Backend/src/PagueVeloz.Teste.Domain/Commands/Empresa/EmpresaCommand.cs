using PagueVeloz.Teste.Domain.Core;

namespace PagueVeloz.Teste.Domain.Commands.Empresa
{
    public abstract class EmpresaCommand : Command
    {
        public string NomeFantasia { get; protected set; }
        public Cnpj Cnpj { get; protected set; }
        public string Uf { get; protected set; }
    }
}