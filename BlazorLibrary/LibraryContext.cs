using BlazorLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorLibrary
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<LibraryMember> LibraryMembers { get; set; }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                 new Author { Id = 1, FirstName = "Bob", LastName = "Smith" },
                 new Author { Id = 2, FirstName = "Billy", LastName = "Smith" },
                 new Author { Id = 3, FirstName = "Jane", LastName = "Smith" }
            });


            modelBuilder.Entity<Book>().HasData(new []
            {
                new { Id = 1, Title = "Cool Book1", AuthorId = 1 },
                new { Id = 2, Title = "Cool Book2", AuthorId = 1 },
                new { Id = 3, Title = "Cool Book3", AuthorId = 2 }
            });
        }
    }
}
