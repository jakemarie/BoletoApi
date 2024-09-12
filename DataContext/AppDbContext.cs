using BoletoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BoletoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<BoletoModel> Boletos { get; set; }
    }
}
