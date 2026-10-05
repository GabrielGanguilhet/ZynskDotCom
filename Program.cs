using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// ======================================================
// SERVIÇOS
// ======================================================

// Razor Pages (.cshtml)
builder.Services.AddRazorPages();

// Controllers (API)
builder.Services.AddControllers();

// Health Check
builder.Services.AddHealthChecks();


var app = builder.Build();


// ======================================================
// MIDDLEWARE
// ======================================================

app.UseHttpsRedirection();

app.UseRouting();

app.UseStaticFiles();

app.UseAuthorization();


// ======================================================
// ROTAS
// ======================================================

// Páginas Razor
// "/" -> Pages/Index.cshtml
app.MapRazorPages();

// Controllers da API
// "/api/..."
app.MapControllers();

// Health Check
// "/health"
app.MapHealthChecks("/health");


// ======================================================
// INICIA O SERVIDOR
// ======================================================

app.Run();
