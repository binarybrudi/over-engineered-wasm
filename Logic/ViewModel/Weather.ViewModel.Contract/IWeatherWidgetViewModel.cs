using System.ComponentModel;
using Brudibytes.MVVM;
using Diamond.Logic.ViewModel.Weather.ViewModel.Contract.DataClasses;

namespace Diamond.Logic.ViewModel.Weather.ViewModel.Contract;

public interface IWeatherWidgetViewModel : INotifyPropertyChanged, ILoadDataAsync
{
    CurrentWeatherRecord CurrentWeatherRecord { get; }
}
