using ERPAPP.Components;
using Microsoft.EntityFrameworkCore; // Needed for UseMySql/UseMySQL
using ERPAPP.Data;                  // Your DbContext namespace (example)

var builder = WebApplication.CreateBuilder(args);

// Existing Blazor services
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ADD EF CORE REGISTRATION HERE
// Replace "MyDbConnection" with the key in your appsettings.json
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MyDbConnection"),
        // For Pomelo.EntityFrameworkCore.MySql (auto-detect server version)
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("MyDbConnection"))
    )
);

// Build the app
var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Existing Blazor endpoints
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
