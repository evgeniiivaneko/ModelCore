using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ModelCore.DataAccess;

namespace ModelCore
{
    public partial class CatalogContext : DbContext
    {
        public virtual DbSet<AccessRights> AccessRights { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Conditioner> Conditioner { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }

        // Unable to generate entity type for table 'dbo.Heater'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-MSI;Initial Catalog=Catalog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessRights>(entity =>
            {
                entity.HasKey(e => e.PK_AccessRightsId);

                entity.Property(e => e.PK_AccessRightsId).HasColumnName("PK_AccessRightsId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.PK_BrandId);

                entity.HasIndex(e => e.FK_Image)
                    .HasName("UQ__Brand__2C75D17A6AB8B844")
                    .IsUnique();

                entity.Property(e => e.PK_BrandId).HasColumnName("PK_BrandId");

                entity.Property(e => e.Contact)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.Property(e => e.FK_Image).HasColumnName("FK_Image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Conditioner>(entity =>
            {
                entity.HasKey(e => e.FkProductId);

                entity.HasIndex(e => e.FkProductId)
                    .HasName("UQ__Conditio__E10D3FC0266B40E0")
                    .IsUnique();

                entity.Property(e => e.FkProductId)
                    .HasColumnName("FK_ProductId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Coolant).HasMaxLength(128);

                entity.Property(e => e.ExternalDimension).HasMaxLength(128);

                entity.Property(e => e.IndoorDimension).HasMaxLength(128);

                entity.Property(e => e.Mode).HasMaxLength(128);

                entity.Property(e => e.TempCold).HasMaxLength(128);

                entity.Property(e => e.TempHot)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Type).HasMaxLength(128);

                entity.Property(e => e.TypeBlock).HasMaxLength(128);

                entity.HasOne(d => d.FkProduct)
                    .WithOne(p => p.Conditioner)
                    .HasForeignKey<Conditioner>(d => d.FkProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Conditioner");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.PK_ImageId);

                entity.Property(e => e.PK_ImageId).HasColumnName("PK_ImageId");

                entity.Property(e => e.Description).HasMaxLength(128);

                entity.Property(e => e.FkProduct).HasColumnName("FK_Product");

                entity.Property(e => e.FkReview).HasColumnName("FK_Review");

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasColumnType("image");

                entity.HasOne(d => d.FkProductNavigation)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.FkProduct)
                    .HasConstraintName("FK_Product_Image");

                entity.HasOne(d => d.FkReviewNavigation)
                    .WithMany(p => p.Image)
                    .HasForeignKey(d => d.FkReview)
                    .HasConstraintName("FK_Review_Image");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.PK_OrderId);

                entity.Property(e => e.PK_OrderId).HasColumnName("PK_OrderId");

                entity.Property(e => e.Comment).HasMaxLength(1024);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.FkProduct).HasColumnName("FK_Product");

                entity.Property(e => e.FkUser).HasColumnName("FK_User");

                entity.HasOne(d => d.FkProductNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.FkProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Order");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.FkUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Order");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PK_ProductId);

                entity.HasIndex(e => e.FkImage)
                    .HasName("UQ__Product__2C75D17A1AC9A590")
                    .IsUnique();

                entity.Property(e => e.PK_ProductId).HasColumnName("PK_ProductId");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.Property(e => e.FkBrand).HasColumnName("FK_Brand");

                entity.Property(e => e.FkImage).HasColumnName("FK_Image");

                entity.Property(e => e.FkType).HasColumnName("FK_Type");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.FkBrandNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.FkBrand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brand_Product");

                entity.HasOne(d => d.FkImageNavigation)
                    .WithOne(p => p.Product)
                    .HasForeignKey<Product>(d => d.FkImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Image_Product");

                entity.HasOne(d => d.FkTypeNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.FkType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Type_Product");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.PkReviewId);

                entity.Property(e => e.PkReviewId).HasColumnName("PK_ReviewId");

                entity.Property(e => e.FkProduct).HasColumnName("FK_Product");

                entity.Property(e => e.FkUser).HasColumnName("FK_User");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.HasOne(d => d.FkProductNavigation)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.FkProduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Review");

                entity.HasOne(d => d.FkUserNavigation)
                    .WithMany(p => p.Review)
                    .HasForeignKey(d => d.FkUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Review");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasKey(e => e.PK_TypeId);

                entity.Property(e => e.PK_TypeId).HasColumnName("PK_TypeId");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.PK_UserId);

                entity.HasIndex(e => e.FkImage)
                    .HasName("UQ__User__2C75D17A6A2D4210")
                    .IsUnique();

                entity.Property(e => e.PK_UserId).HasColumnName("PK_UserId");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FkAccessRights).HasColumnName("FK_AccessRights");

                entity.Property(e => e.FkImage).HasColumnName("FK_Image");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FkAccessRightsNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.FkAccessRights)
                    .HasConstraintName("FK_AccessRights_User");

                entity.HasOne(d => d.FkImageNavigation)
                    .WithOne(p => p.User)
                    .HasForeignKey<User>(d => d.FkImage)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Image_User");
            });
        }
    }
}
