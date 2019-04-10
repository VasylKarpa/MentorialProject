using System.Collections.Generic;

namespace MentorialProject.Domain.Interfaces.IRepository {
  public interface IRepository<TEntity> {
    IEnumerable<TEntity> GetAll();
    TEntity Get(int id);
    void AddOrUpdate(TEntity entity);
    void Delete(TEntity entity);
  }
}
