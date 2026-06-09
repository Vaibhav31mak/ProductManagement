var builder = WebApplication.CreateBuilder(args);

builder.Services.BuildApiWithSwagger();

builder.Services.AddGlobalException();

var app = builder.Build();

app.AddMiddlewarePipeline();

app.Run();
