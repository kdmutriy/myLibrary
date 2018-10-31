using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myLibrary.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author[]
                {
                    new Author{Id=1,NameAuthor="Пушкин Александр Сергеевич",YearBirth=1799,Country="Россия"},
                    new Author{Id=2, NameAuthor="Лермонтов Михаил Юрьевич",YearBirth=1838,Country="Россия"},
                    new Author{Id=3, NameAuthor="Булгаков Михаил Афанасьевич",YearBirth=1891,Country="Россия"}
                });
            modelBuilder.Entity<Book>().HasData(
                new Book[]
                {
                    new Book{Id=1,AuthorId=1, NameBook="Капитанская дочька",YearPublish=1836, Publisher="НИГМА", CountPage=160},
                    new Book{Id=2,AuthorId=1, NameBook="Полтава",YearPublish=1829, Publisher="Художественный фонд", CountPage=24},
                    new Book{Id=3,AuthorId=2, NameBook="Герой нашего времени",YearPublish=1985, Publisher="Азбука", CountPage=224},
                    new Book{Id=4,AuthorId=3, NameBook="Мастер и Маргарита",YearPublish=1960, Publisher="Азбука", CountPage=480}
                });
        }
    }
}
