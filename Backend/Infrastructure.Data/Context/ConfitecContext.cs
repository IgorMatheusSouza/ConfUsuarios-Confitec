namespace Infrastructure.Data.Context
{
    using Domain.Entity;
    using Microsoft.EntityFrameworkCore;

    public class ConfitecContext : DbContext
    {
        public ConfitecContext(DbContextOptions<ConfitecContext> options) : base(options) { }

        private DbSet<Usuario> Usuarios { get; set; }
    }
}