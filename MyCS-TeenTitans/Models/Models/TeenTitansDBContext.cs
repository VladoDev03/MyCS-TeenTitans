using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data.Models
{
    public partial class TeenTitansDBContext : DbContext
    {
        public TeenTitansDBContext()
        {
        }

        public TeenTitansDBContext(DbContextOptions<TeenTitansDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankClerk> BankClerks { get; set; }
        public virtual DbSet<BankClerksLogin> BankClerksLogins { get; set; }
        public virtual DbSet<BankUser> BankUsers { get; set; }
        public virtual DbSet<File> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=TeenTitansDB;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<BankClerk>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__BankCler__536C85E438229F17")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("ID");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BankClerksLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BankClerksLogin");

                entity.Property(e => e.BankClerkName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateAndTime).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("ID");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BankClerksLo__ID__30F848ED");
            });

            modelBuilder.Entity<BankUser>(entity =>
            {
                entity.HasKey(e => e.AccountNum)
                    .HasName("PK__BankUser__B9572BDA4E6093B8");

                entity.Property(e => e.AccountNum).HasMaxLength(10);

                entity.Property(e => e.CreditScore)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.CreditStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateOfLastScore).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasIndex(e => e.FileName, "UQ__Files__589E6EEC03061727")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("ID");

                entity.Property(e => e.BankClerkId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("BankClerkID");

                entity.Property(e => e.DateAndTime).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.BankClerk)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.BankClerkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Files__BankClerk__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
