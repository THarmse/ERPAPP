using ERPAPP.Data;
using Microsoft.EntityFrameworkCore;

namespace ERPAPP.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        {
        }

        public DbSet<MyItem> MyItems { get; set; }
    }
}
