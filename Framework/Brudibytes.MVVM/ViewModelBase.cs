using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Brudibytes.MVVM;

public abstract class ViewModelBase : INotifyPropertyChanged, ILoadDataAsync
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public virtual Task LoadDataAsync()
    {
        return Task.CompletedTask;
    }
}
