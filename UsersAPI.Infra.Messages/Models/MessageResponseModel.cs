namespace UsersAPI.Infra.Messages.Models;

public class MessageResponseModel
{
    public string? MailTo { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
}