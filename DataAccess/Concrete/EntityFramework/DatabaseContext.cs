using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;


namespace DataAccess.Concrete.EntityFramework
{
    public class DatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=TicketSystem;User Id=postgres;Password=Aksaray68!;");
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
