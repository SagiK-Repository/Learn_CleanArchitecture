namespace ExisitingDataBaseToCode.Models;

public partial class Product
{
    public string IdWithName => $"{Id}_{Name}";
}
