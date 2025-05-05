using System.ComponentModel.DataAnnotations;
using CardSignal.Core.Enums;

namespace CardSignal.Application.Dto;

public class UserDto
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Surname { get; set; }
    
    [Required]
    [StringLength(32)]
    public string Password { get; set; }
    
    [Required]
    public Geo Geo { get; set; } = Geo.None;
    
    [Required]
    public Guid OfficeId { get; set; }
}