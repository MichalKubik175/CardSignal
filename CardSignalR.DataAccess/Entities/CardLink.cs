using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardSignalR.DataAccess.Entities;

public class CardLink
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public DateTime ExpirationDate { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    [Required]
    [ForeignKey("User")] 
    public Guid UserId { get; set; }
    
    public virtual User User { get; set; }
}