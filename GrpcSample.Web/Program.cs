﻿using GrpcSample.Web.Infrastructures;
using GrpcSample.Web.Interceptors;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ProtoFileProvider>();

builder.Services.AddGrpc(options =>
{
    options.EnableDetailedErrors = true; // نمایش خطای Exception
    options.Interceptors.Add<ExceptionInterceptor>();
});
builder.Services.AddGrpcReflection();

var app = builder.Build();
app.MapGrpcReflectionService();

// Configure the HTTP request pipeline.
app.MapGrpcService<GrpcSample.Web.Services.v1.PersonGrpcService>();
app.MapGrpcService<GrpcSample.Web.Services.v2.PersonGrpcService>();


app.MapGet("/protos", (ProtoFileProvider protoFileProvider) =>
{
    return Results.Ok(protoFileProvider.GetAll());
});
app.MapGet("/protos/v{version:int}/{protoName}/view",async (ProtoFileProvider protoFileProvider , int version , string protoName) =>
{
    string fileContent = await protoFileProvider.GetContent(version, protoName);
    if (string.IsNullOrEmpty(fileContent))
        return Results.NotFound();
    return Results.File(fileContent);
});

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
