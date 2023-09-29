

using Domain.Contracts;
using Domain.Models.Request;
using Domain.Models.Response;
using Domain.Models.Transacao;
using Extensions;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
                  .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                  .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
                  .AddEnvironmentVariables()
                  .Build();

builder.Services.AddDomainAdapter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddKeycloakAuth(configuration, builder);
builder.Services.AddSwaggerAdapter();
builder.Services.AddAuthorization();

var app = builder.Build();


//#Routes

app.MapPost("pix/transacao", async (SistemaRequest request, IPixService _service) => { await _service.ProcessarTransacao(new TransacaoRequest(request)); })
            .WithTags("Transacao Pix")
            .Accepts<SistemaRequest>("application/json")
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces<BaseError>(StatusCodes.Status400BadRequest)
            .Produces<BaseError>(StatusCodes.Status500InternalServerError)
            .RequireAuthorization();

if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Development" || app.Environment.EnvironmentName == "Local" || app.Environment.EnvironmentName == "Fabrica")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
