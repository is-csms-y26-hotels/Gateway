#pragma warning disable CA1506

using Gateway.Application;
using Gateway.Application.Contracts;
using Gateway.Application.Extensions;
using Gateway.Presentation.Grpc.Extensions;
using Gateway.Presentation.Http.Extensions;
using Gateway.Presentation.Kafka.Extensions;
using Itmo.Dev.Platform.Common.Extensions;
using Itmo.Dev.Platform.Events;
using Itmo.Dev.Platform.Observability;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions<GrpcClientOptions>().BindConfiguration("GrpcClient");
builder.Services.AddGrpcClients();
builder.Services.AddScoped<IGrpcClient, GrpcClient>();

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddOptions<JsonSerializerSettings>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<JsonSerializerSettings>>().Value);

builder.Services.AddPlatform();
builder.AddPlatformObservability();

builder.Services.AddApplication();
builder.Services.AddPresentationGrpc();
builder.Services.AddPresentationKafka(builder.Configuration);
builder.Services
    .AddControllers()
    .AddNewtonsoftJson()
    .AddPresentationHttp();

builder.Services.AddSwaggerGen().AddEndpointsApiExplorer();

builder.Services.AddPlatformEvents(b => b.AddPresentationKafkaHandlers());

builder.Services.AddUtcDateTimeProvider();

WebApplication app = builder.Build();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.UsePlatformObservability();

app.MapControllers();

await app.RunAsync();