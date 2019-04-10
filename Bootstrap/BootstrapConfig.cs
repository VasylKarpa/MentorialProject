using System;
using MentorialProject.DAL.Context;
using MentorialProject.DAL.Enteties;
using MentorialProject.DAL.Repositories;
using MentorialProject.Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrap {
  public static class BootstrapConfig {
    public static void RegisterAppServices(this IServiceCollection services, IConfiguration configuration) {

      services.AddDbContext<SaleDbContext>(options =>
       options.UseSqlServer(configuration.GetConnectionString("MentorialProjectDB")));
      services.AddScoped<IRepository<Sale>, SaleRepository>();

    }
  }
}
