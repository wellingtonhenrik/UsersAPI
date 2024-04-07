using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Infra.Data.Contexts;

namespace UserAPI.Infra.IoC.Extensions
{
    public static class DbContextExtension
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //Capiturando a connectionString do sqlServer
            var connectionString = configuration.GetConnectionString("BDUsersAPI");

            //capiturando o parametro DataBaseProvider
            var databaseProvider = configuration.GetSection("DatabaseProvider").Value;

            //verificando o tipo de provider de banco de dados
            switch (databaseProvider)
            {
                case "SqlServer":
                    services.AddDbContext<DataContext>(options =>
                    {
                        options.UseSqlServer(connectionString);
                    });
                    break;

                case "InMemory":
                    services.AddDbContext<DataContext>(options => {
                        options.UseInMemoryDatabase(databaseName: "BDUserAPI");
                    });
                    break;
            }

            return services;
        }
    }
}
