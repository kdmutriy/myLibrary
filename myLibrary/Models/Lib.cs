using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string NameBook { get; set; }
        public int YearPublish { get; set; }
        public string Publisher { get; set; }
        public int CountPage { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }


    }
    public class Author
    {
        public int Id { get; set; }
        public string NameAuthor { get; set; }
        public int YearBirth{get;set;}
        public string Country { get; set; }
        public List<Book> Books { get; set; }
        public Author()
        {
            Books = new List<Book>();
        }
    }
   
}
