using System.Linq;
using System.Threading.Tasks;
using Copa.Domain;
using Microsoft.EntityFrameworkCore;

namespace Copa.Repository
{
    public class CopaRepository : ICopaRepository
    {
        public readonly CopaContext _context;

        public CopaRepository(CopaContext context)
        {
            _context = context;

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAssync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Chave[]> GetAllChaveAssync(bool notIncludeFinalizada)
        {
            IQueryable<Chave> query = _context.Chaves
                .Include(s => s.Selecao1)
                .Include(s => s.Selecao2);

                if(notIncludeFinalizada)
                    query = query.Where(c =>c.QtqGols1 == int.MinValue && c.QtdGols2 == int.MinValue);

                query = query.OrderBy(c => c.DataConfronto);

                return await query.ToArrayAsync();
        }

        public async Task<Chave> GetAllChaveAssyncById(int id)
        {
            IQueryable<Chave> query = _context.Chaves
                .Include(s => s.Selecao1)
                .Include(s => s.Selecao2);

            return await query.FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task<Selecao[]> GetAllSelecaoAssync(bool notIncludeEliminada)
        {
            IQueryable<Selecao> query = _context.Selecoes;

            if(notIncludeEliminada)    
                query = query.Where(s => s.Eliminada == false);

            query = query.OrderBy(g => g.Grupo).ThenBy(e => e.Eliminada).ThenBy(p => p.Pais);

            return await query.ToArrayAsync();
        }

        public async Task<Selecao> GetAllSelecaoAssyncById(int id)
        {
            IQueryable<Selecao> query = _context.Selecoes;

            return await query.FirstOrDefaultAsync(s => s.Id == id);
        }


    }
}