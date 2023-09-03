using Fiap.Noticias.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Infra.Data.Mappings
{
    public class NoticiaMapping : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(Max)");

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(p => p.Autor)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.DataPublicacao)
                .IsRequired();

            builder.ToTable("Noticias");
        }
    }
}
