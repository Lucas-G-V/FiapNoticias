using Fiap.Noticias.Domain.Interfaces.Repositories;
using Fiap.Noticias.Domain.Model.Entities;
using Fiap.Noticias.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly NoticiaDbContext _db;
        private readonly DbSet<Usuario> _dbSet;
        public UsuarioRepository(NoticiaDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<Usuario>();
        }
        public async Task<Usuario> GetByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
