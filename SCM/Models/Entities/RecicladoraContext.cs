using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SCM.Models.Entities
{
    public partial class RecicladoraContext : DbContext
    {
        public RecicladoraContext()
        {
        }

        public RecicladoraContext(DbContextOptions<RecicladoraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Container> Container { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentStatus> DocumentStatus { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<ManagementProduct> ManagementProduct { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }
        public virtual DbSet<Waste> Waste { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-69AAQ1V;Database=Recicladora;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId)
                    .HasColumnName("CompanyID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Adress).HasMaxLength(500);

                entity.Property(e => e.CompanyName).HasMaxLength(250);

                entity.Property(e => e.ContacName).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Target).HasMaxLength(100);
            });

            modelBuilder.Entity<Container>(entity =>
            {
                entity.Property(e => e.ContainerId).HasColumnName("ContainerID");

                entity.Property(e => e.ContainerDescription).HasMaxLength(200);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Business).HasMaxLength(200);

                entity.Property(e => e.CustomerName).HasMaxLength(500);

                entity.Property(e => e.Phone).HasMaxLength(50);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.DocumentId)
                    .HasColumnName("DocumentID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DocumentStatusId).HasColumnName("DocumentStatusID");

                entity.Property(e => e.LicensePlate).HasMaxLength(50);

                entity.Property(e => e.ReceptionDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.WasteId).HasColumnName("WasteID");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_Document_Company");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Document_Customer");

                entity.HasOne(d => d.DocumentStatus)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.DocumentStatusId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Document_DocumentStatus");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Document_User");
            });

            modelBuilder.Entity<DocumentStatus>(entity =>
            {
                entity.Property(e => e.DocumentStatusId)
                    .HasColumnName("DocumentStatusID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.Property(e => e.HistoryId).HasColumnName("HistoryID");

                entity.Property(e => e.ContainerName).HasMaxLength(200);

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.LicensePlate).HasMaxLength(50);

                entity.Property(e => e.ManagementName).HasMaxLength(250);

                entity.Property(e => e.ProductName).HasMaxLength(200);

                entity.Property(e => e.ReceptionDate).HasColumnType("datetime");

                entity.Property(e => e.Unit).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(300);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.History)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_History_Customer");
            });

            modelBuilder.Entity<ManagementProduct>(entity =>
            {
                entity.HasKey(e => e.ManagementId);

                entity.Property(e => e.ManagementId)
                    .HasColumnName("ManagementID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ManagementName).HasMaxLength(250);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(200);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsersId);

                entity.Property(e => e.UsersId).HasColumnName("UsersID");

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_User_UserType");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.Property(e => e.UserTypeId)
                    .HasColumnName("UserTypeID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserType1)
                    .HasColumnName("UserType")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Waste>(entity =>
            {
                entity.Property(e => e.WasteId).HasColumnName("WasteID");

                entity.Property(e => e.ContainerId).HasColumnName("ContainerID");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.ManagementId).HasColumnName("ManagementID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Unit).HasMaxLength(50);

                entity.HasOne(d => d.Container)
                    .WithMany(p => p.Waste)
                    .HasForeignKey(d => d.ContainerId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Waste_Container");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.Waste)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Waste_Document");

                entity.HasOne(d => d.Management)
                    .WithMany(p => p.Waste)
                    .HasForeignKey(d => d.ManagementId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Waste_ManagementProduct");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Waste)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Waste_Product");
            });
        }
    }
}
