using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MentorialProject.DAL.Context;
using MentorialProject.DAL.Enteties;
using MentorialProject.Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MentorialProject.DAL.Repositories {
  public class SaleRepository : IRepository<Sale>{

    readonly SaleDbContext _saleDbContext;

    public SaleRepository(SaleDbContext context) {
      _saleDbContext = context;
    }

    public IEnumerable<Sale> GetAll() {
      return _saleDbContext.Sales.ToList();
    }

    public Sale Get(int id) {
      return _saleDbContext.Sales
            .FirstOrDefault(e => e.id == id);
    }

    public void AddOrUpdate(Sale sale) {
      var entry = this._saleDbContext.Entry(sale);

      switch (entry.State) {
        case EntityState.Detached:
          this._saleDbContext.Set<Sale>().Add(sale);
          break;
        case EntityState.Modified:
          this._saleDbContext.Set<Sale>().Update(sale);
          break;
        case EntityState.Added:
          this._saleDbContext.Set<Sale>().Add(sale);
          break;
        case EntityState.Unchanged:
          //item already in db no need to do anything  
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
      _saleDbContext.SaveChanges();
    }

    public void Delete(Sale sale) {
      _saleDbContext.Sales.Remove(sale);
      _saleDbContext.SaveChanges();
    }
  }
}