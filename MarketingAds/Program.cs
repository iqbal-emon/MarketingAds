using Google.Api.Ads.Common.Lib;
using MarketingAds.Data;
using MarketingAds.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// Register HttpClient and GetDataService
builder.Services.AddSingleton(new Uri("https://localhost:7235"));

builder.Services.AddHttpClient<GetData>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{ }).AddEntityFrameworkStores<Marketing>();
builder.Services.AddTransient<Marketing>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
