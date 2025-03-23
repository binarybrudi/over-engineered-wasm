using Brudibytes.Core.Contract.Bootstrapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Diamond.CrossCutting.DIRegistration;

public class Bootstrapper  : IBootstrapper
{
    public void ActivateAll(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        
    }
}