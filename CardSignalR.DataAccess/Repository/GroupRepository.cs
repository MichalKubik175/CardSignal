using CardSignalR.DataAccess.Entities;
using CardSignalR.DataAccess.Interface;
using CardSignalR.Exception.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CardSignalR.DataAccess.Repository;

public class GroupRepository : IGroupRepository
{
    private readonly DataBaseContext _context;
    
    public GroupRepository(DataBaseContext dataBaseContext)
    {
        _context = dataBaseContext;
    }
    
    public async Task<Group> CreateGroupAsync(Group group)
    {
        if (await GroupExistsAsync(group.Name))
            throw new GroupAreAlreadyExistException("Group with the same name are already exists");

        _context.Groups.Add(group);
        await _context.SaveChangesAsync();

        return group;
    }

    public async Task DeleteGroupAsync(Group group)
    {
        var result = await _context.Groups.FirstOrDefaultAsync(x => x.Name == group.Name);
        if (result != null)
        {
            _context.Groups.Remove(result);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Group>> GetAllGroupsAsync()
    {
        return await _context.Groups.ToListAsync();
    }

    public async Task<Group> GetGroupAsync(string groupName)
    {
        return await _context.Groups.FirstOrDefaultAsync(x => x.Name == groupName) 
               ?? throw new GroupNotFoundException("Group is not exist!");
    }
    
    public async Task<bool> GroupExistsAsync(string groupName)
    {
        return await _context.Groups.AnyAsync(x => x.Name == groupName);
    }
}