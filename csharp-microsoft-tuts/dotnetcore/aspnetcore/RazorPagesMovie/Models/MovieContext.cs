using System;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Models
{
    public class MovieContext : DbContext
    {

        // This is the database class. The database is called MvcMovie.db.
        // To perform a migration, you can either use the NuGet pkg console => Add-Migration Test; Update-Database
        // or using the terminal => dotnet ef migrations add Test; dotnet ef database update

        public MovieContext(DbContextOptions<MovieContext> options) : base(options){
            
        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Schedule> Schedule { get; set; }

    }
}
