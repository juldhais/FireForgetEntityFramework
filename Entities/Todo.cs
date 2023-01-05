namespace FireForgetEntityFramework.Entities;

public class Todo
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}