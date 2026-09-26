using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PhungXuanCuong2410900014_exam.Models;

public partial class PxcEmployee2410900014DbContext : DbContext
{
    public PxcEmployee2410900014DbContext()
    {
    }

    public PxcEmployee2410900014DbContext(DbContextOptions<PxcEmployee2410900014DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PxcEmployee> PxcEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-UO1B46CE\\SQLEXPRESS;Database=PxcEmployee_2410900014_Db;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PxcEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PxcEmplo__3214EC07B63ECB8B");

            entity.ToTable("PxcEmployee");

            entity.Property(e => e.PxcActive).HasDefaultValue(true);
            entity.Property(e => e.PxcEmail)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PxcName).HasMaxLength(100);
            entity.Property(e => e.PxcPhone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
