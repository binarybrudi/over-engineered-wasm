using System.ComponentModel;
using Diamond.Logic.ViewModel.Weather.ViewModel.Contract.DataClasses;

namespace Diamond.Logic.ViewModel.Weather.ViewModel.Contract;

public interface IWeatherWidgetViewModel : INotifyPropertyChanged
{
    CurrentWeatherForecast CurrentWeatherForecast { get; }
    void RequestCurrentWeatherForecast();
}
