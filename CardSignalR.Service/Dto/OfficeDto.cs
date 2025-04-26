using System.ComponentModel.DataAnnotations;

namespace CardSignalR.Service.Dto;

public class OfficeDto
{
    [Required]
    public string Name { get; set; }
}