using CardSignalR.DataAccess.Entities;
using CardSignalR.DataAccess.Interface;
using CardSignalR.Service.Dto;
using CardSignalR.Service.Interfaces;

namespace CardSignalR.Service.Services;

public class OfficeService : IOfficeService
{
    private readonly IOfficeRepository _officeRepository;
    
    public OfficeService(IOfficeRepository officeRepository)
    {
        _officeRepository = officeRepository;
    }

    public Task<Office> GetOffice(Guid officeDtoId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Office>> GetOffices()
    {
        throw new NotImplementedException();
    }

    public Task<Office> UpdateOffice(OfficeDto office)
    {
        throw new NotImplementedException();
    }

    public void DeleteOffice(OfficeDto office)
    {
        throw new NotImplementedException();
    }
}