using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class prContext : DbContext
    {
        public prContext()
        {
        }

        public prContext(DbContextOptions<prContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Exchange> Exchanges { get; set; } = null!;
        public virtual DbSet<Janre> Janres { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserBook> UserBooks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.IdAuthor);

                entity.ToTable("Author");

                entity.Property(e => e.IdAuthor)
                   
                    .HasColumnName("id_author");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.IdBook);

                entity.ToTable("Book");

                entity.HasIndex(e => e.IdAuthor, "IX_Relationship1");

                entity.Property(e => e.IdBook)
                    
                    .HasColumnName("id_book");

                entity.Property(e => e.IdAuthor).HasColumnName("id_author");

                entity.Property(e => e.Library)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("library");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("written");

                entity.HasMany(d => d.IdJanres)
                    .WithMany(p => p.IdBooks)
                    .UsingEntity<Dictionary<string, object>>(
                        "JanreBook",
                        l => l.HasOne<Janre>().WithMany().HasForeignKey("IdJanre").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("by the book"),
                        r => r.HasOne<Book>().WithMany().HasForeignKey("IdBook").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("has janre"),
                        j =>
                        {
                            j.HasKey("IdBook", "IdJanre");

                            j.ToTable("Janre_Book");

                            j.IndexerProperty<int>("IdBook").HasColumnName("id_book");

                            j.IndexerProperty<int>("IdJanre").HasColumnName("id_janre");
                        });
            });

            modelBuilder.Entity<Exchange>(entity =>
            {
                entity.HasKey(e => e.IdExchange);

                entity.ToTable("Exchange");

                entity.HasIndex(e => e.IdUserBook, "IX_gives");

                entity.HasIndex(e => e.Addresse, "IX_receives");

                entity.Property(e => e.IdExchange)
                    
                    .HasColumnName("id_exchange");

                entity.Property(e => e.Addresse).HasColumnName("addresse");

                entity.Property(e => e.DateOfExchange)
                    .HasColumnType("date")
                    .HasColumnName("date_of_exchange");

                entity.Property(e => e.IdUserBook).HasColumnName("id_userBook");

                entity.HasOne(d => d.AddresseNavigation)
                    .WithMany(p => p.Exchanges)
                    .HasForeignKey(d => d.Addresse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("receives");

                entity.HasOne(d => d.IdUserBookNavigation)
                    .WithMany(p => p.Exchanges)
                    .HasForeignKey(d => d.IdUserBook)
                    .HasConstraintName("gives");
            });

            modelBuilder.Entity<Janre>(entity =>
            {
                entity.HasKey(e => e.IdJanre);

                entity.ToTable("Janre");

                entity.Property(e => e.IdJanre)
                    
                    .HasColumnName("id_janre");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.IdUser)
                    
                    .HasColumnName("id_user");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("login");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .HasColumnName("nickname");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<UserBook>(entity =>
            {
                entity.HasKey(e => e.IdUserBook);

                entity.ToTable("User_Book");

                entity.HasIndex(e => e.IdBook, "IX_contains");

                entity.HasIndex(e => e.IdUser, "IX_has");

                entity.Property(e => e.IdUserBook)
                    
                    .HasColumnName("id_userBook");

                entity.Property(e => e.DateOfDelivery)
                    .HasColumnType("date")
                    .HasColumnName("date_of_delivery");

                entity.Property(e => e.DateOfTake)
                    .HasColumnType("date")
                    .HasColumnName("date_of_take");

                entity.Property(e => e.IdBook).HasColumnName("id_book");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.StatusAfter)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status_after");

                entity.Property(e => e.StatusBefore)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status_before");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.UserBooks)
                    .HasForeignKey(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("contains");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserBooks)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("has");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
