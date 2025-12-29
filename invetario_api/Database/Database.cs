using invetario_api.Modules.categories.entity;
using invetario_api.Modules.products.entity;
using invetario_api.Modules.unit.entity;
using invetario_api.Modules.users.entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace invetario_api.database
{
    public class Database : DbContext
    {
        public DbSet<User> users {  get; set; }
        public DbSet<Category> categories { get; set; }

        public DbSet<Unit> units { get; set; }

        public DbSet<Product> products { get; set; }

        public Database(DbContextOptions<Database> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
