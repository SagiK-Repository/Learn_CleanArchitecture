using ProviderDB_SQLite.Data;
using ProviderDB_SQLite.Models;

using ContosoPizzaPart1Context context = new();

Product veggieSpecial = new Product()
{
    Name = "Veggie Special Pizza",
    Price = 9.99M
};
context.Products.Add(veggieSpecial);

Product deluxeMeat = new Product()
{
    Name = "Deluxe Meat Pizza",
    Price = 12.99M
};
context.Products.Add(deluxeMeat);

context.SaveChanges();