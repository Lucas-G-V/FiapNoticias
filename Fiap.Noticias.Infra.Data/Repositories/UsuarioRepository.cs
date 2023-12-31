﻿using Fiap.Noticias.Domain.Interfaces.Repositories;
using Fiap.Noticias.Domain.Model.Entities;
using Fiap.Noticias.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> Criar(Usuario usuario)
        {
            _dbSet.Add(usuario);
            return await _db.SaveChangesAsync();
        }

    }
}
