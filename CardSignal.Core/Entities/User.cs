using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CardSignal.Core.Enums;

namespace CardSignal.Core.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Surname { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public byte[] PasswordHash { get; set; }

    [Required] 
    public byte[] PasswordSalt { get; set; }
    
    [Required]
    public Role Role { get; set; }

    [Required]
    public Geo Geo { get; set; } = Geo.None;

    [Required]
    [ForeignKey("Office")] 
    public Guid OfficeId { get; set; }
    
    public virtual ICollection<CardLink> CardLinks { get; set; }
}