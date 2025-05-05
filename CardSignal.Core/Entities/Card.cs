using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardSignal.Core.Entities;

public class Card
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public string CardHolderName { get; set; }
    
    public string CardNumber { get; set; }
    
    public int CVV { get; set; }
    
    public string ExpirationDate { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public string CardHolderIp { get; set; }
    
    [Required]
    [ForeignKey("CardLink")] 
    public Guid CardLinkId { get; set; }
}