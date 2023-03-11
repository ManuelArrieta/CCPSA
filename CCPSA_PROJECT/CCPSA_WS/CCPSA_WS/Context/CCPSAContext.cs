using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CCPSA_WS.ModelsContext;
using Microsoft.Extensions.Configuration;

namespace CCPSA_WS.Context
{
    public partial class CCPSAContext : DbContext
    {
        IConfiguration configuration;
        public CCPSAContext(IConfiguration config_)
        {
            this.configuration = config_;
        }

        public CCPSAContext(DbContextOptions<CCPSAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banner> Banners { get; set; } = null!;
        public virtual DbSet<ConfigUpdate> ConfigUpdates { get; set; } = null!;
        public virtual DbSet<ImagenLectura> ImagenLecturas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("CONECTION_STRING"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.HasKey(e => e.Idbanner)
                    .HasName("PRIMARY");

                entity.ToTable("banner");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Idbanner)
                    .ValueGeneratedNever()
                    .HasColumnName("idbanner");

                entity.Property(e => e.AltoImagen).HasColumnName("altoImagen");

                entity.Property(e => e.AnchoImagen).HasColumnName("anchoImagen");

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.NombreImagen)
                    .HasMaxLength(250)
                    .HasColumnName("nombreImagen");

                entity.Property(e => e.TipoArchivo)
                    .HasMaxLength(45)
                    .HasColumnName("tipoArchivo");
            });

            modelBuilder.Entity<ConfigUpdate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("config_update");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(512)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Id)
                    .HasMaxLength(45)
                    .HasColumnName("id");
            });

            modelBuilder.Entity<ImagenLectura>(entity =>
            {
                entity.HasKey(e => e.Idimagen)
                    .HasName("PRIMARY");

                entity.ToTable("imagen_lectura");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Idimagen)
                    .ValueGeneratedNever()
                    .HasColumnName("idimagen");

                entity.Property(e => e.AltoImagen).HasColumnName("altoImagen");

                entity.Property(e => e.AnchoImagen).HasColumnName("anchoImagen");

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.NombreImagen)
                    .HasMaxLength(200)
                    .HasColumnName("nombreImagen");

                entity.Property(e => e.TipoArchivo)
                    .HasMaxLength(45)
                    .HasColumnName("tipoArchivo");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("productos");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(100)
                    .HasColumnName("codigo")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500)
                    .HasColumnName("descripcion")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Existencia)
                    .HasMaxLength(100)
                    .HasColumnName("existencia");

                entity.Property(e => e.Precio)
                    .HasMaxLength(100)
                    .HasColumnName("precio");

                entity.Property(e => e.Pum)
                    .HasMaxLength(100)
                    .HasColumnName("pum");

                entity.Property(e => e.Referencia)
                    .HasMaxLength(100)
                    .HasColumnName("referencia");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
