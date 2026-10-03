using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Início básico de um app web ASP.NET Core (Minimal + Controllers)
// Compatível com .NET 10 / C# 14 

var builder = WebApplication.CreateBuilder(args);

// Serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.RoutePrefix = string.Empty); // Swagger UI disponível em /
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Endpoints
app.MapControllers();
app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapHealthChecks("/health");

// Inicia a aplicação
app.Run();


// Exemplo simples de controller — pode remover ou mover para outro arquivo
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new { Message = "Aplicação Web iniciada com sucesso." });
}