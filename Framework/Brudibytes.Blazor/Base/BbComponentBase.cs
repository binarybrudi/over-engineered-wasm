using Microsoft.AspNetCore.Components;

namespace Brudibytes.Blazor.Base;

public class BbComponentBase : ComponentBase
{
    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
        OnAfterFirstRender();
    }
    
    protected virtual void OnAfterFirstRender() { }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        base.OnAfterRenderAsync(firstRender);
        return OnAfterFirstRenderAsync();
    }
    
    protected virtual Task OnAfterFirstRenderAsync()
        => Task.CompletedTask;
}