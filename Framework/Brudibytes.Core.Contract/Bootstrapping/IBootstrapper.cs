using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Brudibytes.Core.Contract.Bootstrapping;

public interface IBootstrapper
{
    void ActivateAll(IServiceCollection serviceCollection, IConfiguration configuration);
}