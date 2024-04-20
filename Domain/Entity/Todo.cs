using Domain.Enums;

namespace Domain.Entity;

public class Todo
{
    public int Id { get; set; }
    public string? Task { get; set; }
    public TaskActivation TaskActivation { get; set; }
    public DateTime DateOnly { get; set; }

}