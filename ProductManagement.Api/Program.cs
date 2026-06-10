var builder = WebApplication.CreateBuilder(args);

builder.Services.BuildApiWithSwagger();

builder.Services.AddGlobalException();

builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

var app = builder.Build();

app.AddMiddlewarePipeline();

app.Run();
