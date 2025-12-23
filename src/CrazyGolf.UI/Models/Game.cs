namespace CrazyGolf.UI.Models;

public class Game
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DatePlayed { get; set; } = DateTime.Now;
    public int HoleCount { get; set; } = 9; // Default
    public List<Player> Players { get; set; } = new();
    public bool IsComplete { get; set; }
}
