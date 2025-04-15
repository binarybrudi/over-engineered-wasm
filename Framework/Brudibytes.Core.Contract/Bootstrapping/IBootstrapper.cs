using Brudibytes.Core.EventBus.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace Brudibytes.Core.Contract.Bootstrapping;

public interface IBootstrapper
{
    void ActivatingAll();
    void ActivatedAll();
    void DeactivatedAll();
    void DeactivatingAll();
    void RegisterAllMappings(IServiceCollection serviceCollection);
    void AddAllMessageSubscriptions(IEventBus eventBus);
}
