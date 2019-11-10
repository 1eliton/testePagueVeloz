using System;

namespace PagueVeloz.Teste.Domain.Interfaces
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Empresa GetByIdIncludeFornecedor(Guid id);
    }
}