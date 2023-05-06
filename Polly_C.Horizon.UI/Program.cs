using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Polly_C.Horizon.UI.AppState;
using Polly_C.Horizon.UI.WebApiWrapperInterfaces;
using Polly_C.Horizon.UI.WebApiWrapperInterfaces.ClientServicing;
using Polly_C.Horizon.UI.WebApiWrapperInterfaces.Utilities;
using Polly_C.Horizon.UI.Wrappers;
using Polly_C.Horizon.UI.Wrappers.ClientServicing;
using Polly_C.Horizon.UI.Wrappers.Utilities;
using Radzen;

//using Polly_C.Horizon.WebAPI.PolicySearch.Services;
using Serilog;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager _config = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
var logger = new LoggerConfiguration()
                          .ReadFrom.Configuration(builder.Configuration)
                          .Enrich.FromLogContext()
                          .WriteTo.RollingFile("/Logs/log-{Date}.txt")
                          .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddScoped(sp => new HttpClient()

            .EnableIntercept(sp));


builder.Services.AddTransient<IAuthenticationService, AuthenticationWebApiWrapper>();



builder.Services.AddScoped<RefreshTokenService>();
builder.Services.AddScoped<SelectedPolicyState>();
builder.Services.AddHttpClientInterceptor();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IClientServicingWebApiWrapper, ClientServicingWebApiWrapper>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<HttpInterceptorService>();

//Dialog Service
builder.Services.AddScoped<DialogService>();

builder.Services.AddScoped<IHttpClientWrapper, HttpClientWrapper>();
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
