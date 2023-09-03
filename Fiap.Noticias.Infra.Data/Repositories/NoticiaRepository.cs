using Fiap.Noticias.Domain.Interfaces.Repositories;
using Fiap.Noticias.Domain.Model.Entities;
using Fiap.Noticias.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Noticias.Infra.Data.Repositories
{
    public class NoticiaRepository : INoticiaRepository
    {
        private readonly NoticiaDbContext _db;
        private readonly DbSet<Noticia> _dbSet;
        public NoticiaRepository(NoticiaDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Noticia>();
        }
        public async Task<int> Add(Noticia noticia)
        {
            _dbSet.Add(noticia);
            return await SaveChanges();
        }

        public async Task<List<Noticia>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Noticia> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<int> Update(Noticia noticia)
        {
            _dbSet.Update(noticia);
            return await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}
