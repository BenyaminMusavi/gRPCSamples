using GrpcClientSample.Console;
using Microsoft.Extensions.Logging;

var loggerFactory = LoggerFactory.Create(c =>
{
    c.AddConsole();
    c.SetMinimumLevel(LogLevel.Trace);
});

var caller = new GrpcCaller(loggerFactory);

await caller.ClientStreaming();
