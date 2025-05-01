using System.ComponentModel.DataAnnotations;

namespace CardSignalR.Service.Dto;

public class CardLinkDto
{
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Link { get; set; }
    
    public DateTime ExpirationDate { get; set; } = DateTime.UtcNow.AddHours(1);
    
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    
    public Guid UserId { get; set; }
}