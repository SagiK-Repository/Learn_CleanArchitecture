using System.ComponentModel.DataAnnotations.Schema;

namespace Entity_Framework_Core_for_Beginners.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // null을 허용하지 않는 다는 의미에서 null!를 사용할 수 있습니다.

    [Column(TypeName = "decimal(6, 2)")]
    public decimal Price { get; set; }
}
