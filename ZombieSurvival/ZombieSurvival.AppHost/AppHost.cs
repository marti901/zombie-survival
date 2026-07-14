var builder = DistributedApplication.CreateBuilder(args);

var worldService = builder.AddProject<Projects.ZombieSurvival_WorldService>("zombiesurvival-worldservice");

builder.AddContainer("frontend", "nginx")
	.WithBindMount("../Frontend", "/usr/share/nginx/html")
	.WithHttpEndpoint(targetPort: 80)
	.WaitFor(worldService);

builder.Build().Run();