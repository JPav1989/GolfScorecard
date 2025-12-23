using CrazyGolf.UI.Models;

namespace CrazyGolf.UI.Services;

public interface IGameState
{
    // Data Properties
    Game CurrentGame { get; }
    List<Game> GameHistory { get; }

    // Events
    event Action OnChange;

    // Actions
    Task InitializeGameAsync(int holeCount, List<string> playerNames);
    void UpdateScore(string playerName, int holeIndex, int newScore);
    Task FinishGameAsync();
    Task LoadHistoryAsync(); // Load past games when app starts
}
