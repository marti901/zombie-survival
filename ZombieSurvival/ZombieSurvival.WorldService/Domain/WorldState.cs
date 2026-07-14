using ZombieSurvival.Shared.Math;

namespace ZombieSurvival.WorldService.Domain;

public class WorldState
{
	public List<Vector2D> ZombieLocations { get; set; } = [];
}
