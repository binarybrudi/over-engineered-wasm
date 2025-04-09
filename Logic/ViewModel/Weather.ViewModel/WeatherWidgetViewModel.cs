using Brudibytes.MVVM;
using Diamond.Logic.ViewModel.Weather.ViewModel.Contract;
using Diamond.Logic.ViewModel.Weather.ViewModel.Contract.DataClasses;

namespace Diamond.Logic.ViewModel.Weather.ViewModel;

public class WeatherWidgetViewModel : ViewModelBase, IWeatherWidgetViewModel
{
    public CurrentWeatherForecast CurrentWeatherForecast { get; }

    public WeatherWidgetViewModel()
    {
        CurrentWeatherForecast = new()
        {
            Humidity = 0,
            Temperature = 0,
            WindSpeed = 0,
        };
    }
    
    public void RequestCurrentWeatherForecast()
    {
        
    }
}
