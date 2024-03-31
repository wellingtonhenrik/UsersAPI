using Microsoft.EntityFrameworkCore;
using UserApi.Domain.Models;

namespace UsersApi.Infra.Data.Contexts;

public class DataContext : DbContext
{
    //mapeando os modelos de dominio deste contexto
    public DbSet<User> Users { get; set; }
    
    //sobrescrevendo o metodo OnConfiguration para definir o tipo de banco de dados do projeto
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //definindo o banco de dados do contexto
        optionsBuilder.UseInMemoryDatabase(databaseName: "db_users");
    }
}