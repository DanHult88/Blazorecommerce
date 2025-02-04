using BlazorWebShop.Components;
using BlazorWebShop.Data;
using BlazorWebShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Lägg till Entity Framework Core med SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Lägg till Razor-komponenter och Blazor Server
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Lägg till andra tjänster för appen här (t.ex. services, authentication, etc.)
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();  // För Blazor Server

var app = builder.Build();

// Konfigurera HTTP-förfrågningar
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// Konfigurera routing för Blazor Server och Razor Pages
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapBlazorHub();  // För Blazor Server
app.MapFallbackToPage("/_Host");  // För Razor Pages

app.Run();
