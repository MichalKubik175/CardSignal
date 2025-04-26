using CardSignalR.DataAccess.Entities;
using CardSignalR.DataAccess.Interface;
using CardSignalR.Exception.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CardSignalR.DataAccess.Repository;

public class OfficeRepository : IOfficeRepository
{
    private readonly DataBaseContext _context;
    
    public OfficeRepository(DataBaseContext dataBaseContext)
    {
        _context = dataBaseContext;
    }
    
    public async Task<Office> CreateOfficeAsync(Office office)
    {
        if (await OfficeExistsAsync(office.Name))
            throw new OfficeAreAlreadyExistException("Group with the same name are already exists");

        _context.Offices.Add(office);
        await _context.SaveChangesAsync();

        return office;
    }

    public async Task DeleteOfficeAsync(Office office)
    {
        var result = await _context.Offices.FirstOrDefaultAsync(x => x.Name == office.Name);
        if (result != null)
        {
            _context.Offices.Remove(result);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Office>> GetAllOfficesAsync()
    {
        return await _context.Offices.ToListAsync();
    }

    public async Task<Office> GetOfficeAsync(string groupName)
    {
        return await _context.Offices.FirstOrDefaultAsync(x => x.Name == groupName) 
               ?? throw new OfficeNotFoundException("Office is not exist!");
    }
    
    public async Task<bool> OfficeExistsAsync(string groupName)
    {
        return await _context.Offices.AnyAsync(x => x.Name == groupName);
    }
}