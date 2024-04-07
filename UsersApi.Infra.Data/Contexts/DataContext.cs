using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserApi.Domain.Models;
using UsersApi.Infra.Data.Configurations;

namespace UsersApi.Infra.Data.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
            
    }
    
    //adicionando as configuraçõesdemodelos deentidades do banco de  dados (ORM)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        //Dessa forma mapea todos os campos que herdam do EntityType assim não precisaria ir colocando as classes de ORM aqui
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    //mapeando os modelos de dominio deste contexto
    public DbSet<User> Users { get; set; }
    
}