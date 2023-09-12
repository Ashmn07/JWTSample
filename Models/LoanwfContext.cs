using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SampleJWTApp.Models;

public partial class LoanwfContext : DbContext
{
    public LoanwfContext()
    {
    }

    public LoanwfContext(DbContextOptions<LoanwfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerLogin> CustomerLogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WINDOWS-BVQNF6J;Database=loanwf;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__customer__D837D05F0C943140");

            entity.ToTable("customer");

            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Cname)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cname");
            entity.Property(e => e.Doj)
                .HasColumnType("date")
                .HasColumnName("doj");
        });

        modelBuilder.Entity<CustomerLogin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("customer_login");

            entity.Property(e => e.IsEmployee).HasColumnName("isEmployee");
            entity.Property(e => e.Pwd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pwd");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
