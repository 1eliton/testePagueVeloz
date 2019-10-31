using System.Threading.Tasks;
using PagueVeloz.Teste.Domain.Interfaces;

namespace PagueVeloz.Teste.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PagueVelozContext _context;

        public UnitOfWork(PagueVelozContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}