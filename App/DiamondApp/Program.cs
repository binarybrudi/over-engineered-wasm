using Brudibytes.Core.Bootstrapping;
using Brudibytes.Core.Contract.Bootstrapping;
using Brudibytes.Core.Contract.DependencyInjection;
using Brudibytes.Core.EventBus;
using Brudibytes.Core.EventBus.Contract;
using Brudibytes.Core.Microsoft.DependencyInjection.Adapter;
using Diamond.Vertical.ComponentMapping;
using DiamondApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

InitializeApplication(builder.Services, builder.Configuration);

await builder.Build().RunAsync();
return 0;

void InitializeApplication(IServiceCollection serviceCollection, IConfiguration configuration)
{
    var kernel = new CoCoKernelAdapter(new ServiceCollection());
    kernel.AddTransient<IBootstrapper, Bootstrapper>();
    kernel.AddTransient<IEventBus, InMemoryEventBus>();
    IComponentMap componentMap = new ComponentMap();
    componentMap.Initialize(kernel);
    kernel.Build();

    //Activate components
    var bootstrapper = kernel.Get<IBootstrapper>();
    bootstrapper.ActivatingAll();
    bootstrapper.ActivatedAll();
    bootstrapper.RegisterAllMappings(serviceCollection);

    var eventBus = kernel.Get<IEventBus>();
    bootstrapper.AddAllMessageSubscriptions(eventBus);
    serviceCollection.AddSingleton<IEventBus>(eventBus);
}