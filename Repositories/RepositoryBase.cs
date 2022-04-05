using consultaCliente.Database;
using consultaCliente.Dominios;
using consultaConsulta.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace consultaCliente.Repositories.Contracts {
    public class RepositoryBase : IRepositoryBase {
        private readonly DataContext _context;

        public RepositoryBase(DataContext context) {
            _context = context;
        }
        public void Delete(int id) {
            var User = _context.Users.Find(id);
            _context.Users.Remove(User);
        }

        public IEnumerable<User> Get() {
            return _context.Users.ToList();
        }

        public User GetByID(int id) {
            return _context.Users.Find(id);
        }

        public void Insert(User model) {
            _context.Users.Add(model);
            _context.SaveChanges();
         
        }
        public void Update(User model) {
            _context.Entry(model).State = EntityState.Modified;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}