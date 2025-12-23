using CrazyGolf.UI.Services;
using Blazored.LocalStorage;
using MudBlazor.Services;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCrazyGolfServices(this IServiceCollection services)
    {
        // 1. Add MudBlazor (UI)
        services.AddMudServices();

        // 2. Add LocalStorage (Persistence)
        services.AddBlazoredLocalStorage();

        // 3. Add our Game State Service
        services.AddScoped<IGameState, GameState>();

        return services;
    }
}