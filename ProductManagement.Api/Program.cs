var builder = WebApplication.CreateBuilder(args);

builder.Services.BuildApiWithSwagger();

builder.Services.AddGlobalException();

builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddInfrastructureServices();

var app = builder.Build();

app.AddMiddlewarePipeline();

app.Run();
