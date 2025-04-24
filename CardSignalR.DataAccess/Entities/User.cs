using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardSignalR.DataAccess.Entities;

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
    public byte[] PasswordHash { get; set; }
    
    [Required]
    public byte[] PasswordSalt { get; set; }
    
    public Guid GroupId { get; set; }
    
    public virtual ICollection<CardLink> CardLinks { get; set; }
}