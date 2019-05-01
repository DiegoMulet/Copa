using System.Threading.Tasks;
using Copa.Domain;

namespace Copa.Repository
{
    public interface ICopaRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveChangesAssync();

         Task<Selecao[]> GetAllSelecaoAssync(bool notIncludeEliminada);
         Task<Selecao> GetAllSelecaoAssyncById(int id);
         
         Task<Chave[]> GetAllChaveAssync(bool notIncludeFinalizada);
         Task<Chave> GetAllChaveAssyncById(int id);


    }
}