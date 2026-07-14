using ZombieSurvival.WorldService.Domain;

namespace ZombieSurvival.WorldService.Endpoints;

public static class WorldStateEndpoints
{
	public static WorldState TempWorldState = new();

	public static void MapWorldStateEndpoints(this WebApplication app)
	{
		// app.MapGet("world-state", () => Results.Ok(new WorldState()));
		app.MapGet("world-state", () => Results.Ok(TempWorldState));
	}
}
