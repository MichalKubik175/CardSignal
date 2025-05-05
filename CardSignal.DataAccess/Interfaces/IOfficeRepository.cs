using CardSignal.Core.Entities;

namespace CardSignal.DataAccess.Interfaces;

public interface IOfficeRepository
{
    void AddOffice(Office office);
    
    void DeleteOffice(Office office);
    
    Task<List<Office>> GetAllOfficesAsync();
    
    Task<Office> GetOfficeAsync(string officeName);

    Task<bool> OfficeExistsAsync(string officeName);
}