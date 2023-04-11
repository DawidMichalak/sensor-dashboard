using sensor.Api;
using sensor.Api.Messaging;
using sensor.Application.Readings.Commands;
using sensor.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

var policyName = "frontend";

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(AddReadingCommand).Assembly);
});

builder.Services.Configure<MessagingConfiguration>(builder.Configuration.GetSection("Messaging"));
builder.Services.Configure<MongoDbConfiguration>(builder.Configuration.GetSection("MongoDb"));

builder.Services.AddMessaging();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddCorsConfiguration(builder.Configuration, policyName);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(policyName);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
