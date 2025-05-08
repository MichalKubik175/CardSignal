using CardSignal.Application.Dto;

namespace CardSignal.Application.Interfaces;

public interface IOfficeService
{
    public Task<OfficeDto> AddOffice(OfficeDto officeDto);
    public Task<OfficeDto> GetOffice(string officeName);
    
    public Task<List<OfficeDto>> GetOffices();
    
    public Task<OfficeDto> UpdateOffice(OfficeDto office);
    
    public Task DeleteOffice(string name);
}