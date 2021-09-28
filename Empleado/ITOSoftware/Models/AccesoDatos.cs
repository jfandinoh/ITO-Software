using Microsoft.EntityFrameworkCore;

namespace ITOSOFTWARE.Models{

    public class LibraryDbContext : DbContext
    {   
        public LibraryDbContext(DbContextOptions<LibraryDbContext> data) :base (data){}    

            public DbSet<Empleado> Empleado{get; set;}

    }
}