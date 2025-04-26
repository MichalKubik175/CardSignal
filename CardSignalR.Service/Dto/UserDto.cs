using System.ComponentModel.DataAnnotations;
using CardSignalR.DataAccess.Enum;

namespace CardSignalR.Service.Dto;

public class UserDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Surname { get; set; }
    
    [Required]
    public Geo Geo { get; set; } = Geo.None;
    
    public Guid OfficeId { get; set; }
}