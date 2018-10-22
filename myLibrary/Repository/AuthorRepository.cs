using Microsoft.EntityFrameworkCore;
using myLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myLibrary.Repository
{
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
