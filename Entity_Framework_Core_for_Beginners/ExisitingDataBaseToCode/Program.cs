using ExisitingDataBaseToCode.Data;
using ExisitingDataBaseToCode.Models;

using ContosoPizzaPart1Context context = new();

foreach (Product product in context.Products)
    Console.WriteLine($"Name : {product.IdWithName}");