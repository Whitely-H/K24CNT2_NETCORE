using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PxcLesson10.Models;

public partial class PxcK24cnt2lesson10Context : DbContext
{
    public PxcK24cnt2lesson10Context()
    {
    }

    public PxcK24cnt2lesson10Context(DbContextOptions<PxcK24cnt2lesson10Context> options)
        : base(options)
    {
    }

    public virtual DbSet<PxcMember> PxcMembers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-UO1B46CE\\SQLEXPRESS;Database=PxcK24CNT2Lesson10;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PxcMember>(entity =>
        {
            entity.ToTable("PxcMember");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PxcEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PxcFullName).HasMaxLength(50);
            entity.Property(e => e.PxcPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PxcPhone)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PxcUserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
