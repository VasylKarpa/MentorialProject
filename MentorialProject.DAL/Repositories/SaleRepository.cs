using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MentorialProject.DAL.Context;
using MentorialProject.DAL.Enteties;
using MentorialProject.Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MentorialProject.DAL.Repositories {
  public class SaleRepository : IRepository<Sale> {

    readonly SaleDbContext _saleDbContext;

    public SaleRepository(SaleDbContext context) {
      _saleDbContext = context;
    }

    public async Task<IEnumerable<Sale>> GetAll() {
      return await _saleDbContext.Sales.ToListAsync();
    }

    public async Task<Sale> Get(int id) {
      return await _saleDbContext.Sales.FirstOrDefaultAsync(e => e.id == id);
    }

    public async Task AddOrUpdate(Sale sale) {
      var entry = _saleDbContext.Entry(sale);

      switch (entry.State) {
        case EntityState.Detached:
          _saleDbContext.Set<Sale>().Add(sale);
          break;
        case EntityState.Modified:
          _saleDbContext.Set<Sale>().Update(sale);
          break;
        case EntityState.Added:
          await _saleDbContext.Set<Sale>().AddAsync(sale);
          break;
        case EntityState.Unchanged:
          //item already in db no need to do anything  
          break;
        default:
          throw new ArgumentException();
      }
     await _saleDbContext.SaveChangesAsync();
    }

    public async Task Delete(Sale sale) {
      _saleDbContext.Sales.Remove(sale);
     await _saleDbContext.SaveChangesAsync();
    }
  }
}