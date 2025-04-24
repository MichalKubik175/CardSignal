using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CardSignalR.DataAccess.Enum;

namespace CardSignalR.DataAccess.Entities;

public class Group
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public Geo Geo { get; set; }
}