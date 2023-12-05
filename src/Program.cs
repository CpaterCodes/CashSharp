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

RouteGroupBuilder helloWorldApi = app.MapGroup("/hello-world");

helloWorldApi.MapGet("/", () => "Hello World!");

app.Run();

public record Todo(
	int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false
);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
