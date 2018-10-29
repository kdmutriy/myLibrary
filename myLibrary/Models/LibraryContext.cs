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
            modelBuilder.Entity<Book>().HasData(
                new Book[]
                {
                    new Book{NameBook="Капитанская дочька",YearPublish=1836, Publisher="НИГМА", CountPage=160,
                        Author =new Author{NameAuthor="Пушкин Александр Сергеевич",YearBirth=1799,Country="Россия"} },
                    new Book{NameBook="Полтава",YearPublish=1829, Publisher="Художественный фонд", CountPage=24,
                       Author =new Author{NameAuthor="Пушкин Александр Сергеевич",YearBirth=1799,Country="Россия"} },
                    new Book{NameBook="Герой нашего времени",YearPublish=1985, Publisher="Азбука", CountPage=224,
                        Author =new Author{NameAuthor="Лермонтов Михаил Юрьевич",YearBirth=1838,Country="Россия"} },
                    new Book{NameBook="Мастер и Маргарита",YearPublish=1960, Publisher="Азбука", CountPage=480,
                        Author =new Author{NameAuthor="Булгаков Михаил Афанасьевич",YearBirth=1891,Country="Россия"} }
                });
        }
    }
}
