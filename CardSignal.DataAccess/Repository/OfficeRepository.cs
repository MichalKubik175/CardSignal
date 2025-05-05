using CardSignal.Core.Entities;
using CardSignal.Core.Exceptions;
using CardSignal.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CardSignal.DataAccess.Repository;

public class OfficeRepository : IOfficeRepository
{
    private readonly DataBaseContext _context;
    
    public OfficeRepository(DataBaseContext dataBaseContext)
    {
        _context = dataBaseContext;
    }
    
    public void AddOffice(Office office)
    {
        _context.Offices.Add(office);
    }

    public void DeleteOffice(Office office)
    {
        _context.Offices.Remove(office);
    }

    public async Task<List<Office>> GetAllOfficesAsync()
    {
        return await _context.Offices
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Office> GetOfficeAsync(string officeName)
    {
        return await _context.Offices
                   .AsNoTracking()
                   .FirstOrDefaultAsync(x => x.Name == officeName) 
               ?? throw new OfficeNotFoundException($"Office with provided {officeName} name is not exist!");
    }
    
    public async Task<bool> OfficeExistsAsync(string officeName)
    {
        return await _context.Offices.AnyAsync(x => x.Name == officeName);
    }
}