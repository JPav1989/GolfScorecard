using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CrazyGolf.UI.Models;

public class Game
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DatePlayed { get; set; } = DateTime.Now;
    public int HoleCount { get; set; } = 9; // Default
    public List<Player> Players { get; set; } = new();
    public bool IsComplete { get; set; }
}

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
