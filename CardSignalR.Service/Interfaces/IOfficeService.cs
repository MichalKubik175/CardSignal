using CardSignalR.DataAccess.Entities;
using CardSignalR.Service.Dto;

namespace CardSignalR.Service.Interfaces;

public interface IOfficeService
{
    public Task<OfficeDto> GetOffice(Guid officeDtoId);
    
    public Task<IEnumerable<OfficeDto>> GetOffices();
    
    public Task<OfficeDto> UpdateOffice(OfficeDto office);
    
    public void DeleteOffice(OfficeDto office);
}