using Microsoft.EntityFrameworkCore;
using VirtualStore.ProductApi.Entities;
using VirtualStore.ProductApi.Model;

namespace VirtualStore.ProductApi.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }


    //fluent api serve para configurar as entidades
    //assim como as propriedades delas e seus relacionamentos
    //nesse caso estamos configurando a entidade Category
    //assim quando fizermos uma migration ela vai criar a tabela 
    // de Category conforme essa configuração
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       //category
       modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
       modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();

        //product
        modelBuilder.Entity<Product>().Property(p => p.Name).
            HasMaxLength(100).
            IsRequired();

        modelBuilder.Entity<Product>().Property(p => p.Price).
            HasColumnType("decimal(10,2)").
            IsRequired();

        modelBuilder.Entity<Product>().Property(p => p.Description).
            HasMaxLength(255);

        modelBuilder.Entity<Product>().Property(p => p.ImageUrl).
            HasMaxLength(255).
            IsRequired();

        modelBuilder.Entity<Category>().
            HasMany(c => c.Products).
            WithOne(p => p.Category).
            IsRequired().
            OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Electronics" },
            new Category { CategoryId = 2, Name = "Books" },
            new Category { CategoryId = 3, Name = "Clothing" }
        );
    }
}
