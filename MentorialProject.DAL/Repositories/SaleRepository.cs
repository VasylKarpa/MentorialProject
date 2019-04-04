using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MentorialProject.DAL.Context;
using MentorialProject.DAL.Enteties;
using MentorialProject.Domain.Interfaces.IRepository;

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

    public void Add(Sale entity) {
      _saleDbContext.Sales.Add(entity);
      _saleDbContext.SaveChanges();
    }

    public void Update(Sale data, Sale sale) {

      //var saleResult = data.results;
      //var properties = saleResult.GetType().GetGenericArguments(BindingFlags.Public | BindingFlags.Instance);
      //foreach (var propertie in properties) {
      //  var propertyValue = propertie.GetValue(data);
      //  propertie.SetValue(sale, propertyValue);
      //}

      _saleDbContext.SaveChanges();
    }

    public void Delete(Sale sale) {
      _saleDbContext.Sales.Remove(sale);
      _saleDbContext.SaveChanges();
    }
  }
}