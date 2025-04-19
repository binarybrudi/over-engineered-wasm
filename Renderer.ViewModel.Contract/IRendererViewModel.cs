using System.ComponentModel;
using Brudibytes.MVVM;
using Diamond.Logic.ViewModel.Renderer.ViewModel.Contract.DataClasses;

namespace Diamond.Logic.ViewModel.Renderer.ViewModel.Contract;

public interface IRendererViewModel : INotifyPropertyChanged, ILoadDataAsync
{
    public Dimensions Dimensions { get; }

    void SetDimensions(Dimensions dimensions);
    Task StartRendering(Func<byte[], Task> onBufferCreatedCallback);
}
