namespace Domain.Entity;

public class Register
{
    public int Id { get; set; }
    public string UserName { get; set; } = "Lasath";
    public string EmailAddress { get; set; } = "lasathrathnayake@gmail.com";
    public string Password { get; set; } = "***";
    public ICollection<Todo> Todos { get; set; }
}