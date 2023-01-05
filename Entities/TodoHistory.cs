namespace FireForgetEntityFramework.Entities;

public class TodoHistory
{
    public int Id { get; set; }
    public Todo Todo { get; set; }
    public int TodoId { get; set; }
    public DateTime Date { get; set; }
    public string Remarks { get; set; }
}