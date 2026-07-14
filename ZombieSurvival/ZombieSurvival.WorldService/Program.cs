// TODO: Setup CORS properly
using ZombieSurvival.WorldService.Domain;
using ZombieSurvival.WorldService.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(o =>
{
	o.AddDefaultPolicy(policy =>
	{
		policy
			.AllowAnyHeader()
			.AllowAnyMethod()
			.AllowAnyOrigin();
	});
});

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
else
{
	app.UseHttpsRedirection();
}

app.UseCors();

app.MapWorldStateEndpoints();

Task.Run(() =>
{
	for(int i = 0; i < 1000; i += 16)
	{
		Thread.Sleep(1000);
		WorldStateEndpoints.TempWorldState.ZombieLocations.Add(new ZombieSurvival.Shared.Math.Vector2D(i, i));
	}
});

app.Run();