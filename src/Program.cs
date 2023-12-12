using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(
		options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(
		0, AppJsonSerializerContext.Default
	);
});

WebApplication app = builder.Build();

RouteGroupBuilder authAPI = app.MapGroup("/auth");

authAPI.MapPost("/register", () => Results.Created());

app.Run();

public record Todo(
	int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false
);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
