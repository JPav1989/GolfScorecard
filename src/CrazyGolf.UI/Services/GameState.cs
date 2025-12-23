using Blazored.LocalStorage;
using CrazyGolf.UI.Models;

namespace CrazyGolf.UI.Services
{
    public class GameState : IGameState
    {
        private readonly ILocalStorageService _localStorage;
        private const string HistoryKey = "CrazyGolf_History";

        public Game CurrentGame { get; private set; }
        public List<Game> GameHistory { get; private set; } = new();

        // This event lets components know something changed so they can refresh
        public event Action OnChange;

        public GameState(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task InitializeGameAsync(int holeCount, List<string> playerNames)
        {
            CurrentGame = new Game
            {
                Id = Guid.NewGuid(),
                DatePlayed = DateTime.Now,
                HoleCount = holeCount,
                IsComplete = false,
                Players = new List<Player>()
            };

            // Create players and prepopulate their score list with 0s
            foreach (var name in playerNames)
            {
                var player = new Player
                {
                    Name = name,
                    // Fill list with 0s for every hole so we can access by index later
                    HoleScores = Enumerable.Repeat(0, holeCount).ToList()
                };
                CurrentGame.Players.Add(player);
            }

            NotifyStateChanged();
        }

        public void UpdateScore(string playerName, int holeIndex, int newScore)
        {
            if (CurrentGame == null) return;

            var player = CurrentGame.Players.FirstOrDefault(p => p.Name == playerName);
            if (player != null)
            {
                // Ensure the score is valid (e.g., no negative scores)
                if (newScore < 0) newScore = 0;

                // Update the specific hole (Indices are 0-based, so Hole 1 is index 0)
                player.HoleScores[holeIndex] = newScore;

                NotifyStateChanged();
            }
        }

        public async Task FinishGameAsync()
        {
            if (CurrentGame == null) return;

            CurrentGame.IsComplete = true;

            // Add current game to history
            GameHistory.Add(CurrentGame);

            // Save updated history to browser/phone storage
            await _localStorage.SetItemAsync(HistoryKey, GameHistory);

            NotifyStateChanged();
        }

        public async Task LoadHistoryAsync()
        {
            // Retrieve past games when the app starts up
            var storedHistory = await _localStorage.GetItemAsync<List<Game>>(HistoryKey);
            if (storedHistory != null)
            {
                GameHistory = storedHistory;
                NotifyStateChanged();
            }
        }

        // Helper to trigger the event
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}