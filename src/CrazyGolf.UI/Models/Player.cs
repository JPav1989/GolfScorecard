namespace CrazyGolf.UI.Models;

public class Player
{
    public required string Name { get; set; }
    public string Colour { get; set; } 
    public List<int> HoleScores { get; set; } = new();

    // Helper logic
    public int TotalScore => HoleScores.Sum();
    public int GetScoreForHole(int holeIndex) => HoleScores[holeIndex];

    public int GetBestHole() => HoleScores.IndexOf(HoleScores.Min()) + 1;

}
