using CardSignalR.DataAccess.Entities;

namespace CardSignalR.DataAccess.Interface;

public interface IGroupRepository
{
    Task<Group> CreateGroupAsync(Group group);
    
    Task DeleteGroupAsync(Group group);
    
    Task<IEnumerable<Group>> GetAllGroupsAsync();
    
    Task<Group> GetGroupAsync(string groupName); 
}