using System;
using System.Collections.Generic;
using CvProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CvProject.Data;

public partial class CvContext : DbContext
{
    public CvContext()
    {
    }

    public CvContext(DbContextOptions<CvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAdmin> TblAdmin { get; set; }

    public virtual DbSet<TblDeneyimler> TblDeneyimler { get; set; }

    public virtual DbSet<TblEgitimler> TblEgitimler { get; set; }

    public virtual DbSet<TblHakkinda> TblHakkinda { get; set; }

    public virtual DbSet<TblHobiler> TblHobiler { get; set; }

    public virtual DbSet<TblIletisim> TblIletisim { get; set; }

    public virtual DbSet<TblSertifikalar> TblSertifikalar { get; set; }

    public virtual DbSet<TblYetenekler> TblYetenekler { get; set; }

    public virtual DbSet<TblSosyalMedya> TblSosyalMedya { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=DbCv;Trusted_Connection = True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAdmin>(entity =>
        {
            entity.ToTable("TblAdmin");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.KullaniciAdi).HasMaxLength(20);
            entity.Property(e => e.Sifre).HasMaxLength(20);
        });

        modelBuilder.Entity<TblDeneyimler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TblDeneyimlerim");

            entity.ToTable("TblDeneyimler");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AltBaslik).HasMaxLength(100);
            entity.Property(e => e.Baslik).HasMaxLength(100);
            entity.Property(e => e.Tarih).HasMaxLength(100);
        });

        modelBuilder.Entity<TblEgitimler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TblEgitimlerim");

            entity.ToTable("TblEgitimler");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AltBaslik1).HasMaxLength(100);
            entity.Property(e => e.AltBaslik2).HasMaxLength(100);
            entity.Property(e => e.Baslik).HasMaxLength(100);
            entity.Property(e => e.Gpa)
                .HasMaxLength(10)
                .HasColumnName("GPA");
            entity.Property(e => e.Tarih).HasMaxLength(100);
        });

        modelBuilder.Entity<TblHakkinda>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ad).HasMaxLength(50);
            entity.Property(e => e.Adres).HasMaxLength(100);
            entity.Property(e => e.Mail).HasMaxLength(50);
            entity.Property(e => e.Soyad).HasMaxLength(50);
            entity.Property(e => e.Telefon).HasMaxLength(200);
        });

        modelBuilder.Entity<TblHobiler>(entity =>
        {
            entity.ToTable("TblHobiler");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Aciklama1).HasMaxLength(500);
            entity.Property(e => e.Aciklama2).HasMaxLength(500);
        });

        modelBuilder.Entity<TblIletisim>(entity =>
        {
            entity.ToTable("TblIletisim");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adsoyad).HasMaxLength(100);
            entity.Property(e => e.Konu).HasMaxLength(100);
            entity.Property(e => e.Mail).HasMaxLength(50);
        });

        modelBuilder.Entity<TblSertifikalar>(entity =>
        {
            entity.ToTable("TblSertifikalar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Aciklama).HasMaxLength(250);
            entity.Property(e => e.Tarih).HasMaxLength(100);
            entity.Property(e => e.Kaynak).HasMaxLength(100);
        });

        modelBuilder.Entity<TblYetenekler>(entity =>
        {
            entity.ToTable("TblYetenekler");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Yetenek).HasMaxLength(100);
            entity.Property(e => e.Oran).HasMaxLength(10);
        });

        modelBuilder.Entity<TblSosyalMedya>(entity =>
        {
            entity.ToTable("TblSosyalMedya");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ad).HasMaxLength(100);
            entity.Property(e => e.Icon).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
