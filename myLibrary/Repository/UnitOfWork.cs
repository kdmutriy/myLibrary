using myLibrary.Models;
using myLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myLibrary
{
    public class UnitOfWork : IDisposable
    {
        private LibraryContext db;
        private BookRepository bookRepository;
        private AuthorRepository authorRepository;

        public UnitOfWork(LibraryContext context)
        {
            db = context;
        }
        public BookRepository Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }
        public AuthorRepository Authors
        {
            get
            {
                if (authorRepository == null)
                    authorRepository = new AuthorRepository(db);
                return authorRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if (disposed)
                    db.Dispose();
                this.disposed = true;
            }            
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
