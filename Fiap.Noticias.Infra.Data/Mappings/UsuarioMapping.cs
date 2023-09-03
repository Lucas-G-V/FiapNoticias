using Fiap.Noticias.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Infra.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Senha)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.ToTable("Usuarios");
        }
    }
}
