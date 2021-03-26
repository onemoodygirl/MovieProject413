using System;
using Microsoft.EntityFrameworkCore;

namespace Moody413Assignment3.Models
{
    public class MovieListDbContext : DbContext
    {
        //connect to DB and inherit from base
        public MovieListDbContext (DbContextOptions<MovieListDbContext> options) : base (options)
        {

        }

        public DbSet<FormResponse> Movie { get; set; }

        
    }
}
