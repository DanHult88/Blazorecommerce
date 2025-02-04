using BlazorWebShop.Components;
using BlazorWebShop.Data;
using BlazorWebShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// L�gg till Entity Framework Core med SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// L�gg till Razor-komponenter och Blazor Server
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// L�gg till andra tj�nster f�r appen h�r (t.ex. services, authentication, etc.)
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();  // F�r Blazor Server

var app = builder.Build();

// Konfigurera HTTP-f�rfr�gningar
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

// Konfigurera routing f�r Blazor Server och Razor Pages
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapBlazorHub();  // F�r Blazor Server
app.MapFallbackToPage("/_Host");  // F�r Razor Pages

app.Run();
