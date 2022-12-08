using System.Data.Entity;

namespace Professional_Register_form
{
    class db : DbContext
    {
        public db() : base("name=CSprodbentity") { }
        public DbSet<person> people { set; get; }
    }
}