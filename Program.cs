using WebUIBlazor.Components;
//using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
//using Persistence;
using Microsoft.AspNetCore.Components;
using WebUIBlazor.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ModelService>();
//builder.Services.AddApplicationServices();
//builder.Services.AddPersistenceServices(builder.Configuration);
var apiBaseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
