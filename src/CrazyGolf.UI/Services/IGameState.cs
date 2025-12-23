using CrazyGolf.UI.Models;

namespace CrazyGolf.UI.Services;

public interface IGameState
{
    // Data Properties
    Game CurrentGame { get; }

    // Events
    event Action OnChange;

    // Actions
    Task InitializeGameAsync(int holeCount, List<string> playerNames);
    void UpdateScore(string playerName, int holeIndex, int newScore);
    Task FinishGameAsync();
}
