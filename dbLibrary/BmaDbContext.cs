using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace dbLibrary;

public partial class BmaDbContext : DbContext
{
    public BmaDbContext()
    {
    }

    public BmaDbContext(DbContextOptions<BmaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BmaTable> BmaTables { get; set; }

    public virtual DbSet<ExcepTable> ExcepTables { get; set; }

    public virtual DbSet<GenTable> GenTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-721A9KG;Database=bmaDB;Trusted_Connection=True;TrustServerCertificate=True;");
        optionsBuilder.UseLoggerFactory(MyLoggerFactory);
    }

    public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddProvider(new MyLoggerProvider());
    });

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BmaTable>(entity =>
        {
            entity.ToTable("bmaTable");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Data)
                .HasColumnType("xml")
                .HasColumnName("data");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Feedback).HasColumnType("text");
            entity.Property(e => e.Length).HasColumnType("text");
            entity.Property(e => e.Sequence).HasColumnType("text");
            entity.Property(e => e.State).HasColumnType("text");
        });

        modelBuilder.Entity<ExcepTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_execepTable");

            entity.ToTable("excepTable");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateTime).HasColumnType("date");
            entity.Property(e => e.Form).HasColumnType("text");
            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.TargetSite).HasColumnType("text");
        });

        modelBuilder.Entity<GenTable>(entity =>
        {
            entity.ToTable("genTable");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Feedback).HasColumnType("text");
            entity.Property(e => e.Length).HasColumnType("text");
            entity.Property(e => e.Sequence).HasColumnType("text");
            entity.Property(e => e.SequenceLength)
                .HasColumnType("text")
                .HasColumnName("Sequence_Length");
            entity.Property(e => e.State).HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
