using System.ComponentModel.DataAnnotations;

namespace CardSignal.Application.Dto;

public sealed class UpdateCardLinkDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Link { get; set; }
    
    public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddHours(1);
}