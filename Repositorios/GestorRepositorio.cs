using consultaCliente.Adm.Modelo;
using consultaCliente.Database;
using consultaCliente.Repositorios.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace consultaGestor.Repositorios {
    public class GestorRepositorio: IRepositorioBase<Gestor, int> {
        private readonly DataContext _context;

        public GestorRepositorio(DataContext context) {
            _context = context;
        }
        public void Delete(int id) {
            var User = _context.Gestores.Find(id);
            _context.Gestores.Remove(User);
        }

        public IEnumerable<Gestor> Get() {
            return _context.Gestores.ToList();
        }

        public Gestor GetByID(int id) {
            return _context.Gestores.Find(id);
        }

        public void Insert(Gestor model) {
            _context.Gestores.Add(model);
            _context.SaveChanges();

        }
        public void Update(Gestor model) {
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