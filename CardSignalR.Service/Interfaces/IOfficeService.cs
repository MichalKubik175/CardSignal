using CardSignalR.DataAccess.Entities;
using CardSignalR.Service.Dto;

namespace CardSignalR.Service.Interfaces;

public interface IOfficeService
{
    public Task<Office> GetOffice(Guid officeDtoId);
    
    public Task<IEnumerable<Office>> GetOffices();
    
    public Task<Office> UpdateOffice(OfficeDto office);
    
    public void DeleteOffice(OfficeDto office);
}