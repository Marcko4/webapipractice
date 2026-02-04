using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi1.Models;

namespace webapi1.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<usuario> usuarios { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<usuario>(entity =>
        {
            entity.HasKey(e => e.id).HasName("usuario_pkey");

            entity.Property(e => e.fecha_creacion).HasDefaultValueSql("now()");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
