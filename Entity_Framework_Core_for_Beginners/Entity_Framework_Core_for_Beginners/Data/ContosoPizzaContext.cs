using Entity_Framework_Core_for_Beginners.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Core_for_Beginners.Data;

public class Entity_Framework_Core_for_BeginnersContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(@"Data Source =(localdb)\ProjectModels;Initial Catalog=ContosoPizza-Part1;Integrated Security=True;");
}
