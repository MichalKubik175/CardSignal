using CardSignal.Application.Dto;

namespace CardSignal.Application.Interfaces;

public interface IOfficeService
{
    public Task<OfficeDto> AddOffice(OfficeDto officeDto);
    public Task<OfficeDto> GetOffice(string officeName);
    
    public Task<IEnumerable<OfficeDto>> GetOffices();
    
    public Task<OfficeDto> UpdateOffice(OfficeDto office);
    
    public void DeleteOffice(OfficeDto office);
}