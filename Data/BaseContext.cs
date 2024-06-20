using Microsoft.EntityFrameworkCore;
using RosePark.Models;

namespace RosePark.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set;}
        public DbSet<Persona> Personal { get; set;}
    }
}