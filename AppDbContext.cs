using System;
using System.Collections.Generic;
using CargoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CargoApi.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }

        public virtual DbSet<Cargo> Cargos { get; set; }

        public virtual DbSet<CargoDelivery> CargoDeliveries { get; set; }

        public virtual DbSet<CargoWeight> CargoWeights { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Designation> Designations { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Feedback> Feedbacks { get; set; }

        public virtual DbSet<Inventory> Inventories { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<Material> Materials { get; set; }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Price> Prices { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<Supplier> Suppliers { get; set; }

        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // => optionsBuilder.UseSqlServer("server=DESKTOP-NH2A0HC; database=CargoDB; Integrated Security = True; MultipleActiveResultSets=True; TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.AdminId).HasName("PK__admin__4A311D2F0BF14BBD");

                entity.Property(e => e.AdminId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.CargoId).HasName("PK__cargo__982828C4793D508E");

                entity.Property(e => e.CargoId).ValueGeneratedNever();

                entity.HasOne(d => d.Cust).WithMany(p => p.Cargos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cust_id_");

                entity.HasOne(d => d.Emp).WithMany(p => p.Cargos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emp_id");

                entity.HasOne(d => d.Product).WithMany(p => p.Cargos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_id");
            });

            modelBuilder.Entity<CargoDelivery>(entity =>
            {
                entity.HasKey(e => e.DeliveryId).HasName("PK_Delivery_id");

                entity.Property(e => e.DeliveryId).ValueGeneratedNever();

                entity.HasOne(d => d.Cargo).WithMany(p => p.CargoDeliveries)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cargo");
            });

            modelBuilder.Entity<CargoWeight>(entity =>
            {
                entity.HasKey(e => e.WeightId).HasName("PK_weighht_id");

                entity.Property(e => e.WeightId).ValueGeneratedNever();

                entity.HasOne(d => d.Cargo).WithMany(p => p.CargoWeights)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cargo_id");

                entity.HasOne(d => d.Product).WithMany(p => p.CargoWeights)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("C_product_id");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustId).HasName("PK_cust_id");

                entity.Property(e => e.CustId).ValueGeneratedNever();
                entity.Property(e => e.CustGender).IsFixedLength();
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.HasKey(e => e.DesignationId).HasName("PK_Designation_id");

                entity.Property(e => e.DesignationId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId).HasName("PK_Emp_id");

                entity.Property(e => e.EmpId).ValueGeneratedNever();

                entity.HasOne(d => d.Designation).WithMany(p => p.Employees)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Designation_id");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.FId).HasName("PK_F_id");

                entity.Property(e => e.FId).ValueGeneratedNever();

                entity.HasOne(d => d.Cust).WithMany(p => p.Feedbacks)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cust_id");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.InventoryId).HasName("PK_inventory_id");

                entity.Property(e => e.InventoryId).ValueGeneratedNever();

                entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductId");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId).HasName("PK_invoice_id");

                entity.Property(e => e.InvoiceId).ValueGeneratedNever();

                entity.HasOne(d => d.Order).WithMany(p => p.Invoices)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_id");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.MaterialId).HasName("PK_Material_id");

                entity.Property(e => e.MaterialId).ValueGeneratedNever();

                entity.HasOne(d => d.Sup).WithMany(p => p.Materials)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sup_id");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderId).HasName("PK_order_id");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.HasOne(d => d.Cust).WithMany(p => p.OrderDetails)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cust_id");

                entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_id");

                entity.HasOne(d => d.Service).WithMany(p => p.OrderDetails)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_service_id");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PayId).HasName("PK_pay_id");

                entity.Property(e => e.PayId).ValueGeneratedNever();

                entity.HasOne(d => d.Cust).WithMany(p => p.Payments)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("_cust_id");

                entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order_id");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasOne(d => d.Order).WithMany()
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_id");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId).HasName("PK_Product_id");

                entity.Property(e => e.ProductId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.ServiceId).HasName("PK_Service_id");

                entity.Property(e => e.ServiceId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupId).HasName("PK_Sup_id");

                entity.Property(e => e.SupId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.HasKey(e => e.WarehouseId).HasName("PK_Warehouse_id");

                entity.Property(e => e.WarehouseId).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
