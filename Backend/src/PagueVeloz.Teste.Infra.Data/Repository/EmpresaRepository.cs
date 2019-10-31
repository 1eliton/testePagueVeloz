using PagueVeloz.Teste.Domain;
using PagueVeloz.Teste.Domain.Interfaces;

namespace PagueVeloz.Teste.Infra.Data
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(PagueVelozContext context) : base(context)
        { }
    }
}