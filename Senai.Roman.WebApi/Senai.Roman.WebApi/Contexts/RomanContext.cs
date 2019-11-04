using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Roman.WebApi.Domains
{
    public partial class RomanContext : DbContext
    {
        public RomanContext()
        {
        }

        public RomanContext(DbContextOptions<RomanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aulas> Aulas { get; set; }
        public virtual DbSet<Temas> Temas { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=T_Roman;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aulas>(entity =>
            {
                entity.HasKey(e => e.IdAula);

                entity.Property(e => e.IdAula).HasColumnName("idAula");

                entity.Property(e => e.IdTema).HasColumnName("idTema");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Aulas)
                    .HasForeignKey(d => d.IdTema)
                    .HasConstraintName("FK__Aulas__idTema__4E88ABD4");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Aulas)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Aulas__idUsuario__4D94879B");
            });

            modelBuilder.Entity<Temas>(entity =>
            {
                entity.HasKey(e => e.IdTema);

                entity.Property(e => e.IdTema).HasColumnName("idTema");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(550)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasColumnName("senha")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });
        }
    }
}
