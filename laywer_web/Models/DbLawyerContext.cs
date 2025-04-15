using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace laywer_web.Models;

public partial class DbLawyerContext : DbContext
{
    public DbLawyerContext()
    {
    }

    public DbLawyerContext(DbContextOptions<DbLawyerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbLLawyersdetail> TbLLawyersdetails { get; set; }

    public virtual DbSet<TblAdmin> TblAdmins { get; set; }

    public virtual DbSet<TblAdmindetail> TblAdmindetails { get; set; }

    public virtual DbSet<TblCity> TblCities { get; set; }

    public virtual DbSet<TblContact> TblContacts { get; set; }

    public virtual DbSet<TblCountry> TblCountries { get; set; }

    public virtual DbSet<TblLawyer> TblLawyers { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       

        modelBuilder.Entity<TbLLawyersdetail>(entity =>
        {
            entity.HasKey(e => e.LawyerId);

            entity.ToTable("tbL_lawyersdetail");

            entity.Property(e => e.LawyerId).HasColumnName("lawyer_id");
            entity.Property(e => e.LawyerDealed).HasColumnName("lawyer_dealed");
            entity.Property(e => e.LawyerEmail).HasColumnName("lawyer_email");
            entity.Property(e => e.LawyerImage).HasColumnName("Lawyer_image");
            entity.Property(e => e.LawyerName).HasColumnName("lawyer_name");
            entity.Property(e => e.LawyerNumber).HasColumnName("lawyer_Number");
            entity.Property(e => e.LawyerPassword).HasColumnName("lawyer_password");
        });

        modelBuilder.Entity<TblAdmin>(entity =>
        {
            entity.HasKey(e => e.AdminId);

            entity.ToTable("tbl_admin");

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.AdminEmail).HasColumnName("admin_email");
            entity.Property(e => e.AdminName).HasColumnName("admin_name");
            entity.Property(e => e.AdminPassword).HasColumnName("admin_password");
        });

        modelBuilder.Entity<TblAdmindetail>(entity =>
        {
            entity.HasKey(e => e.AdminId);

            entity.ToTable("tbl_admindetails");

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.AdminEmail).HasColumnName("admin_email");
            entity.Property(e => e.AdminName).HasColumnName("admin_name");
            entity.Property(e => e.AdminPassword).HasColumnName("admin_password");
        });

        modelBuilder.Entity<TblCity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_citi__3213E83F7AABDA85");

            entity.ToTable("tbl_cities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city_name");
            entity.Property(e => e.CountryId).HasColumnName("country_id");

            entity.HasOne(d => d.Country).WithMany(p => p.TblCities)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__tbl_citie__count__55009F39");
        });

        modelBuilder.Entity<TblContact>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("tbl_contact");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserEmail).HasColumnName("user_email");
            entity.Property(e => e.UserMsg).HasColumnName("user_msg");
            entity.Property(e => e.UserName).HasColumnName("user_name");
            entity.Property(e => e.UserSub).HasColumnName("user_sub");
        });

        modelBuilder.Entity<TblCountry>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__tbl_coun__A9FAE80A477FE177");

            entity.ToTable("tbl_country");

            entity.Property(e => e.CId).HasColumnName("C_id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country_name");
        });

        modelBuilder.Entity<TblLawyer>(entity =>
        {
            entity.HasKey(e => e.LawyerId);

            entity.ToTable("tbl_lawyers");

            entity.Property(e => e.LawyerId).HasColumnName("lawyer_id");
            entity.Property(e => e.LawyerEmail).HasColumnName("lawyer_email");
            entity.Property(e => e.LawyerName).HasColumnName("lawyer_name");
            entity.Property(e => e.LawyerPassword).HasColumnName("lawyer_password");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("tbl_user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserEmail).HasColumnName("user_email");
            entity.Property(e => e.UserName).HasColumnName("user_name");
            entity.Property(e => e.UserPassword).HasColumnName("user_password");
        });
        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
