using Google.Api.Ads.Common.Lib;
using MarketingAds.Auth;
using MarketingAds.Components;
using MarketingAds.Data;

using MarketingAdsLibrary.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Radzen;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddScoped<StatusService>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{ }).AddEntityFrameworkStores<Marketing>();
builder.Services.AddTransient<Marketing>();
builder.Services.AddTransient<AuthService>();
builder.Services.AddScoped<AuthStateProvider>();
builder.Services.AddScoped<StatusService>();
builder.Services.AddTransient<CategoryService>();
builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<LocationService>();
builder.Services.AddTransient<ProductService>();


builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<ProtectedLocalStorage>();


builder.Services.AddAuthorizationCore();
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
