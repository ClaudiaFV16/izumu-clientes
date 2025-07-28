using Microservice_Izumu.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservice_Izumu.Data  // Asegúrate de que el namespace coincida con la estructura de tu proyecto
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
