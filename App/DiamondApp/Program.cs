using Brudibytes.Diamond.App.DiamondApp;using Diamond.CrossCutting.DIRegistration;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
new Bootstrapper().ActivateAll(builder.Services, builder.Configuration);

await builder.Build().RunAsync();
