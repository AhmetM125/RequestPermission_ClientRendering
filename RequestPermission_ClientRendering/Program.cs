using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RequestPermission_ClientRendering;
using RequestPermission_ClientRendering.Base;
using RequestPermission_ClientRendering.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddServices();
builder.Services.AddScoped<AuthorizationProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthorizationProvider>();
builder.Services.AddScoped<MainLayoutCascadingValue>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredLocalStorage(/*config=>config.JsonSerializerOptions*/);



builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7044/api/")
});

await builder.Build().RunAsync();
