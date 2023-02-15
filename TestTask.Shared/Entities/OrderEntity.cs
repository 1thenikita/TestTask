using System.ComponentModel.DataAnnotations;
using TestTask.Shared.Models;

namespace TestTask.Shared.Entities;

/// <summary>
/// Сущность операции.
/// </summary>
public class OrderEntity
{
    /// <summary>
    /// ID.
    /// </summary>
    [Key]
    public Guid ID { get; set; }
    
    /// <summary>
    /// Количество списываемых средств.
    /// </summary>
    [Required]
    public float Money { get; set; }
    
    /// <summary>
    /// Номер карты для списывания.
    /// </summary>
    [Required]
    public string CardNumber { get; set; }
    
    /// <summary>
    /// Статус операции.
    /// </summary>
    public OrderStatus Type { get; set; } = OrderStatus.Processing;
}