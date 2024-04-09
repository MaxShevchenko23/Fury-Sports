using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using sport_shop_dal.Entities;

namespace sport_shop_dal.Data;

public partial class FurySportsContext : DbContext
{
    public FurySportsContext()
    {
    }

    public FurySportsContext(DbContextOptions<FurySportsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Specification> Specifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-KKLFTJP;Database=furySports;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(12)
                .HasColumnName("phone_number");
            entity.Property(e => e.Role).HasColumnName("role");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.ToTable("cart");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Account).WithMany(p => p.Carts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cart_accounts");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_cart_products");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.RootCategoryId).HasColumnName("root_category_id");

            entity.HasOne(d => d.RootCategory).WithMany(p => p.InverseRootCategory)
                .HasForeignKey(d => d.RootCategoryId)
                .HasConstraintName("FK_categories_categories");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.ToTable("manufacturers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country)
                .HasMaxLength(25)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.MainCategoryId).HasColumnName("main_category_id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ClientAddress)
                .HasMaxLength(50)
                .HasColumnName("client_address");
            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .HasColumnName("client_name");
            entity.Property(e => e.ClientPhoneNumber)
                .HasMaxLength(12)
                .HasColumnName("client_phone_number");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_orders_accounts");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_orders_products");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_products_categories");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_products_manufacturers");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.ToTable("product images");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(50)
                .HasColumnName("image_url");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product images_products");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("reviews");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Mark)
                .HasColumnType("decimal(5, 0)")
                .HasColumnName("mark");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ReviewContent)
                .HasColumnType("text")
                .HasColumnName("review_content");

            entity.HasOne(d => d.Account).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reviews_accounts");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reviews_products");
        });

        modelBuilder.Entity<Specification>(entity =>
        {
            entity.ToTable("specifications");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SpecificationName)
                .HasMaxLength(50)
                .HasColumnName("specification_name");
            entity.Property(e => e.SpecificationValue)
                .HasMaxLength(50)
                .HasColumnName("specification_value");

            entity.HasOne(d => d.Product).WithMany(p => p.Specifications)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_specifications_products");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
