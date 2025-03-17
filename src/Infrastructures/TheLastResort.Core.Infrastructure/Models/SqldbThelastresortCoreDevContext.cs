using Microsoft.EntityFrameworkCore;

namespace TheLastResort.Core.Infrastructure.Models;

public partial class SqldbThelastresortCoreDevContext : DbContext
{
    public SqldbThelastresortCoreDevContext()
    {
    }

    public SqldbThelastresortCoreDevContext(DbContextOptions<SqldbThelastresortCoreDevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApartmentEntity> ApartmentEntities { get; set; }

    public virtual DbSet<BuildingEntity> BuildingEntities { get; set; }

    public virtual DbSet<HotelEntity> HotelEntities { get; set; }

    public virtual DbSet<LogEntity> LogEntities { get; set; }

    public virtual DbSet<ReservationEntity> ReservationEntities { get; set; }

    public virtual DbSet<UserEntity> UserEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApartmentEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Apartmen__3214EC077D46E4EA");

            entity.ToTable("ApartmentEntity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ManagerPhone).HasMaxLength(50);

            entity.HasOne(d => d.Building).WithOne(p => p.ApartmentEntity)
                .HasForeignKey<ApartmentEntity>(d => d.Id)
                .HasConstraintName("FK_ApartmentEntity_BuildingEntity");
        });

        modelBuilder.Entity<BuildingEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Building__3214EC07013ABE50");

            entity.ToTable("BuildingEntity");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.BuildingType).HasMaxLength(50);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<HotelEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__HotelEnt__3214EC07296D956C");

            entity.ToTable("HotelEntity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(255);

            entity.HasOne(d => d.Building).WithOne(p => p.HotelEntity)
                .HasForeignKey<HotelEntity>(d => d.Id)
                .HasConstraintName("FK_HotelEntity_BuildingEntity");
        });

        modelBuilder.Entity<LogEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LogEntit__3214EC073328503B");

            entity.ToTable("LogEntity");

            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ReservationEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC07F9E6A04E");

            entity.ToTable("ReservationEntity");

            entity.HasIndex(e => e.StartDate, "IDX_ReservationEntity_StartDate");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Cancelled).HasDefaultValue(false);
            entity.Property(e => e.CancelledDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReservationType).HasMaxLength(50);

            entity.HasOne(d => d.Building).WithMany(p => p.ReservationEntities)
                .HasForeignKey(d => d.BuildingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationEntity_BuildingEntity");

            entity.HasOne(d => d.User).WithMany(p => p.ReservationEntities)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationEntity_UserEntity");
        });

        modelBuilder.Entity<UserEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserEnti__3214EC074A1766AB");

            entity.ToTable("UserEntity");

            entity.HasIndex(e => e.Email, "UQ_UserEntity_Email").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
