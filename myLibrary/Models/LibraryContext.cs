using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace myLibrary.Models
{
    public class LibraryContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Lib> Libs { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lib>().
                HasKey(ba => new { ba.BookId, ba.AuthorId });

            modelBuilder.Entity<Lib>()
            .HasOne(sc => sc.Book)
            .WithMany(s => s.Lib)
            .HasForeignKey(sc => sc.BookId);

            modelBuilder.Entity<Lib>()
                .HasOne(sc => sc.Author)
                .WithMany(c => c.Lib)
                .HasForeignKey(sc => sc.AuthorId);

        }
    }
}
