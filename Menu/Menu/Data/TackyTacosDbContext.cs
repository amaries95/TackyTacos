using Menu.Entities;
using Microsoft.EntityFrameworkCore;

namespace Menu.Data;

public partial class TackyTacosDbContext : DbContext
{
    public TackyTacosDbContext(DbContextOptions<TackyTacosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MenuCategory> MenuCategories { get; set; }

    public virtual DbSet<MenuItem> MenuItems { get; set; }

    public virtual DbSet<MenuItemModification> MenuItemModifications { get; set; }

    public virtual DbSet<MenuModification> MenuModifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Menu_Category");

            entity.ToTable("Menu_Categories");

            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<MenuItem>(entity =>
        {
            entity.ToTable("Menu_Items");

            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.MenuItems)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Menu_Items_Menu_Categories");
        });

        modelBuilder.Entity<MenuItemModification>(entity =>
        {
            entity.ToTable("Menu_Item_Modifications");

            entity.Property(e => e.MenuItemId).HasColumnName("Menu_Item_Id");
            entity.Property(e => e.MenuModificationId).HasColumnName("Menu_Modification_Id");

            entity.HasOne(d => d.MenuItem).WithMany(p => p.MenuItemModifications)
                .HasForeignKey(d => d.MenuItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Menu_Item_Modifications_Menu_Items");

            entity.HasOne(d => d.MenuModification).WithMany(p => p.MenuItemModifications)
                .HasForeignKey(d => d.MenuModificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Menu_Item_Modifications_Menu_Modifications");
        });

        modelBuilder.Entity<MenuModification>(entity =>
        {
            entity.ToTable("Menu_Modifications");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
