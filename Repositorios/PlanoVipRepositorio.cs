using consultaCliente.Compartilhado;
using consultaCliente.Database;
using consultaCliente.Repositorios.Contratos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace consultaCliente.Repositorios {
    public class PlanoVipRepositorio : IRepositorioBase<PlanoVip, int> {
        private readonly DataContext _context;

        public PlanoVipRepositorio(DataContext context) {
            _context = context;
        }
        public void Delete(int id) {
            var User = _context.PlanosVips.Find(id);
            _context.PlanosVips.Remove(User);
        }

        public IEnumerable<PlanoVip> Get() {
            return _context.PlanosVips.ToList();
        }

        public PlanoVip GetByID(int id) {
            return _context.PlanosVips.Find(id);
        }

        public void Insert(PlanoVip model) {
            _context.PlanosVips.Add(model);
            _context.SaveChanges();

        }
        public void Update(PlanoVip model) {
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