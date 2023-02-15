using System.ComponentModel.DataAnnotations;
using TestTask.Shared.Models;

namespace TestTask.Shared.Entities;

public class OrderEntity
{
    [Key]
    public Guid ID { get; set; }
    [Required]
    public float Money { get; set; }
    [Required]
    public string CardNumber { get; set; }
    public OrderStatus Type { get; set; } = OrderStatus.Processing;
}