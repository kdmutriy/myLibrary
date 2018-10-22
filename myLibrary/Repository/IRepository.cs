using Microsoft.EntityFrameworkCore;
using myLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myLibrary.Repository
{
    //Паттерн Unit of Work
    interface IRepository<T> 
        where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int Id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);       
    }
}
