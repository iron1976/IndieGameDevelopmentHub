﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IndieGameDevelopmentHub.Models;

public partial class IndieGameDevelopmentHubContext : DbContext
{
    public IndieGameDevelopmentHubContext()
    {
    }

    public IndieGameDevelopmentHubContext(DbContextOptions<IndieGameDevelopmentHubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tester> Testers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=IndieGameDevelopmentHub;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tester>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TESTER__3214EC27561C3FAE");

            entity.ToTable("TESTER");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
