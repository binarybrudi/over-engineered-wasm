using System.ComponentModel;
using Brudibytes.MVVM;
using Microsoft.AspNetCore.Components;

namespace Brudibytes.Blazor;

public abstract class ViewModelComponentBase<TViewModel> : BbComponentBase, IAsyncDisposable, IDisposable
    where TViewModel : class, ILoadDataAsync, INotifyPropertyChanged
{
    private TViewModel _viewModel = default!;

    [Inject]
    public TViewModel ViewModel
    {
        get => _viewModel;
        set
        {
            if (_viewModel is not null)
            {
                _viewModel.PropertyChanged -= OnPropertyChanged;
            }

            _viewModel = value;

            _viewModel.PropertyChanged += OnPropertyChanged;
        }
    }

    protected override async Task OnParametersSetAsync()
    {
        var loadDataTask = _viewModel.LoadDataAsync();
        var baseTask = base.OnParametersSetAsync();
        await Task.WhenAll(loadDataTask, baseTask);
    }


    public virtual void Dispose()
    {
        if (_viewModel is null)
        {
            return;
        }

        _viewModel.PropertyChanged -= OnPropertyChanged;
        if (_viewModel is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }

    public virtual async ValueTask DisposeAsync()
    {
        Dispose();

        if (_viewModel is IAsyncDisposable asyncDisposable)
        {
            await asyncDisposable.DisposeAsync();
        }
    }

    private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        InvokeAsync(StateHasChanged);
    }
}
