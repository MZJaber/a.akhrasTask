using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WebApplication1.Models;

public partial class InfrastructureDbContext : DbContext
{
    public InfrastructureDbContext()
    {
    }

    public InfrastructureDbContext(DbContextOptions<InfrastructureDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Floor> Floors { get; set; }

    public virtual DbSet<Line> Lines { get; set; }

    public virtual DbSet<Node> Nodes { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

    {
        optionsBuilder.UseNpgsql("Host=localhost:5432;Database=infrastructure_db;Username=postgres;Password=20131026");
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<NodeType>();
        modelBuilder.HasPostgresEnum<RowStatus>();

        modelBuilder.Entity<Floor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("floor_pkey");

            entity.ToTable("floor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.VenueId).HasColumnName("venue_id");

            entity.Property(e => e.Status).HasColumnName("status");



            entity.HasOne(d => d.Venue).WithMany(p => p.Floors)
                .HasForeignKey(d => d.VenueId)
                .HasConstraintName("floor_venue_id_fkey");
        });

        modelBuilder.Entity<Line>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("line_pkey");

            entity.ToTable("line");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FirstNodeId).HasColumnName("first_node_id");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.IsTwoWay).HasColumnName("is_two_way");
            entity.Property(e => e.SecondNodeId).HasColumnName("second_node_id");
            entity.Property(e => e.Status).HasColumnName("status").HasConversion<string>();
        });

        modelBuilder.Entity<Node>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("node_pkey");

            entity.ToTable("node");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FloorId).HasColumnName("floor_id");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Lat).HasColumnName("lat");
            entity.Property(e => e.Long).HasColumnName("long");
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.Y).HasColumnName("y");
            entity.Property(e => e.NodeType).HasColumnName("node_type").HasConversion<string>();
            entity.Property(e => e.Status).HasColumnName("status").HasConversion<string>();

            entity.HasOne(d => d.Floor).WithMany(p => p.Nodes)
                .HasForeignKey(d => d.FloorId)
                .HasConstraintName("node_floor_id_fkey");

        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("venue_pkey");

            entity.ToTable("venue");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status").HasConversion<string>();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
