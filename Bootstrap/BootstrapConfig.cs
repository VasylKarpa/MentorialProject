using System;
using System.IO;
using MentorialProject.DAL.Context;
using MentorialProject.DAL.Enteties;
using MentorialProject.DAL.Repositories;
using MentorialProject.Domain.Interfaces;
using MentorialProject.Domain.Interfaces.IRepository;
using MentorialProject.Domain.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrap {
  public static class BootstrapConfig {
    public static void RegisterAppServices(this IServiceCollection services, IConfiguration configuration, IHostingEnvironment environment) {

      var configurationBuilder = new ConfigurationBuilder()
        .AddJsonFile("DAL.appsettings.json", optional: true);
      services.AddDbContext<SaleDbContext>(options =>
       options.UseSqlServer(configuration.GetConnectionString("")));

      services.AddScoped<IRepository<Sale>, SaleRepository>();
      services.AddScoped<IReadFromFileService<Sale>, ReadFromFileService>();


    }
  }
}
