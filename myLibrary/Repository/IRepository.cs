using Microsoft.EntityFrameworkCore;
using myLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myLibrary.Repository
{
    interface IRepository<T> 
        where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);       
    }

    public class BookRepository : IRepository<Book>
    {
        private LibraryContext db;

        public BookRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books;
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public void Create(Book book)
        {
            db.Books.Add(book);
        }

        public void Update(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }
    }

    public class AuthorRepository : IRepository<Author>
    {
        private LibraryContext db;

        public AuthorRepository(LibraryContext context)
        {
            this.db = context;
        }

        public IEnumerable<Author> GetAll()
        {            
            return db.Authors;
        }

        public Author Get(int id)
        {
            return db.Authors.Find(id);
        }

        public void Create(Author order)
        {
            db.Authors.Add(order);
        }

        public void Update(Author order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Author order = db.Authors.Find(id);
            if (order != null)
                db.Authors.Remove(order);
        }
    }
}
