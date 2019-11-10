using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PagueVeloz.Teste.Domain;
using PagueVeloz.Teste.Domain.Interfaces;

namespace PagueVeloz.Teste.Infra.Data
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(PagueVelozContext context) : base(context)
        { }

        public Empresa GetByIdIncludeFornecedor(Guid id) =>
            Set.Where(emp => emp.Id == id).Include(x => x.Fornecedores).FirstOrDefault();
    }
}