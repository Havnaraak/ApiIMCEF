using ApiBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBase.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<Pessoas> Pessoas { get; set; }
    }

}
