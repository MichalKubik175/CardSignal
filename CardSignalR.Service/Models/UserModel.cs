namespace CardSignalR.Service.Models;

public class UserModel
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public Guid GroupId { get; set; }
}