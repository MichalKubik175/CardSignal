using AutoMapper;
using CardSignal.Application.Dto;
using CardSignal.Application.Interfaces;
using CardSignal.Core.Entities;
using CardSignal.Core.Exceptions;
using CardSignal.DataAccess.Interfaces;
using CardSignal.DataAccess.Repository;

namespace CardSignal.Application.Services;

public class OfficeService : IOfficeService
{
    private readonly IOfficeRepository _officeRepository;
    private readonly DataBaseContext _dataBaseContext;
    private readonly IMapper _mapper;
    
    public OfficeService(
        IOfficeRepository officeRepository,
        DataBaseContext dataBaseContext,
        IMapper mapper)
    {
        _officeRepository = officeRepository;
        _dataBaseContext = dataBaseContext;
        _mapper = mapper;
    }

    public async Task<OfficeDto> AddOffice(OfficeDto officeDto)
    {
        if (await _officeRepository.OfficeExistsAsync(officeDto.Name))
        {
            throw new OfficeAreAlreadyExistException($"Office with provided {officeDto.Name} name are already exist!");
        }
        
        var office = _mapper.Map<Office>(officeDto);
        
        _officeRepository.AddOffice(office);
        
        await _dataBaseContext.SaveChangesAsync();
        
        return _mapper.Map<OfficeDto>(office);
    }

    public async Task<OfficeDto> GetOffice(string officeName)
    {
        var office = await _officeRepository.GetOfficeAsync(officeName);
        return _mapper.Map<OfficeDto>(office);
    }

    public Task<IEnumerable<OfficeDto>> GetOffices()
    {
        throw new NotImplementedException();
    }

    public Task<OfficeDto> UpdateOffice(OfficeDto office)
    {
        throw new NotImplementedException();
    }

    public void DeleteOffice(OfficeDto office)
    {
        throw new NotImplementedException();
    }
}