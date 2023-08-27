using CRUD_DEMO.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUD_DEMO.Data
{
    public class Datacontextdb:DbContext
    {
        public Datacontextdb(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Purchase>Purchases { get; set; }
        public DbSet<Registration>Registrations { get; set; }
    }
}
