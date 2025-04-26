using CardSignalR.DataAccess.Entities;

namespace CardSignalR.DataAccess.Interface;

public interface IOfficeRepository
{
    Task<Office> CreateOfficeAsync(Office office);
    
    Task DeleteOfficeAsync(Office office);
    
    Task<IEnumerable<Office>> GetAllOfficesAsync();
    
    Task<Office> GetOfficeAsync(string groupName); 
}