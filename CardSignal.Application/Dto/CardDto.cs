namespace CardSignal.Application.Dto;

public class CardDto
{
    public string CardHolderName { get; set; }
    
    public string CardNumber { get; set; }
    
    public int CVV { get; set; }
    
    public string ExpirationDate { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public string CardHolderIp { get; set; }
    
    public Guid CardLinkId { get; set; }
}