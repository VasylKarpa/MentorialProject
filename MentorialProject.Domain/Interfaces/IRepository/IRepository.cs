using System.Collections.Generic;
using System.Threading.Tasks;

namespace MentorialProject.Domain.Interfaces.IRepository {
  public interface IRepository<TEntity> {
    Task<IEnumerable<TEntity>> GetAll();
    Task<TEntity> Get(int id);
    Task AddOrUpdate(TEntity entity);
    Task Delete(TEntity entity);
  }
}
