using System.ComponentModel.DataAnnotations;

namespace CardSignal.Application.Dto;

public class CardLinkDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Link { get; set; }
    
    public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddHours(1);
    
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    
    public Guid UserId { get; set; }
}