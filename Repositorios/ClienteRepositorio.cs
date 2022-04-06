using consultaCliente.Database;
using consultaCliente.Modelos;
using consultaCliente.Repositorios.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace consultaCliente.Repositorios {
    public class ClienteRepositorio : IRepositorioBase<Cliente, int> {
        private readonly DataContext _context;

        public ClienteRepositorio(DataContext context) {
            _context = context;
        }
        public void Delete(int id) {
            var User = _context.Clientes.Find(id);
            _context.Clientes.Remove(User);
        }

        public IEnumerable<Cliente> Get() {
            return _context.Clientes.ToList();
        }

        public Cliente GetByID(int id) {
            return _context.Clientes.Find(id);
        }

        public void Insert(Cliente model) {
            _context.Clientes.Add(model);
            _context.SaveChanges();
         
        }
        public void Update(Cliente model) {
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