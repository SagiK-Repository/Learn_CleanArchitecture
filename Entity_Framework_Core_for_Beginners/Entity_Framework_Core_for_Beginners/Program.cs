

using Entity_Framework_Core_for_Beginners.Data;
using Entity_Framework_Core_for_Beginners.Models;
using Entity_Framework_Core_for_BeginnersContext context = new();

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