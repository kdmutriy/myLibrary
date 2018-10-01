using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myLibrary.Models
{
    public class Lib
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
    public class Author
    {
        public int Id { get; set; }
        public string NameAuthor { get; set; }
        public IList<Lib> Lib { get; set; }
        public Author()
        {
            Lib = new List<Lib>();
        }
    }
    public class Book
    {
        public int Id { get; set; }
        public string NameBook { get; set; }
        public IList<Lib> Lib { get; set; }
        public Book()
        {
            Lib = new List<Lib>();
        }
    }
}
