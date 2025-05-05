using System.ComponentModel.DataAnnotations;

namespace CardSignal.Application.Dto;

public class OfficeDto
{
    [Required]
    public string Name { get; set; }
}