using MentorialProject.DAL.Enteties;
using Microsoft.EntityFrameworkCore;

namespace MentorialProject.DAL.Context {
  public class SaleDbContext : DbContext {
    public DbSet<Sale> Sales { get; set; }

    public SaleDbContext(DbContextOptions options) : base(options) {
      //will be removed to initializator
      Database.EnsureCreated();
    }
  }
}
