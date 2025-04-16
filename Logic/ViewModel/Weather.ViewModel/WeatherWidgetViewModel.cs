using Brudibytes.Core.EventBus.Contract;
using Brudibytes.MVVM;
using Diamond.Logic.Domain.Weather.Contract;
using Diamond.Logic.Domain.Weather.Contract.Messaging;
using Diamond.Logic.ViewModel.Weather.ViewModel.Contract;
using Diamond.Logic.ViewModel.Weather.ViewModel.Contract.DataClasses;

namespace Diamond.Logic.ViewModel.Weather.ViewModel;

public class WeatherWidgetViewModel : ViewModelBase, IWeatherWidgetViewModel, IEventMessageHandler<CurrentForecastMessage>
{
    private readonly ICurrentWeatherMessageTrigger _currentWeatherMessageTrigger;
    private CurrentWeatherRecord _currentWeatherRecord = new();

    public CurrentWeatherRecord CurrentWeatherRecord
    {
        get => _currentWeatherRecord;
        private set => SetField(ref _currentWeatherRecord, value);
    }

    public WeatherWidgetViewModel(ICurrentWeatherMessageTrigger currentWeatherMessageTrigger)
    {
        _currentWeatherMessageTrigger = currentWeatherMessageTrigger;
    }

    public override Task LoadDataAsync()
    {
        _currentWeatherMessageTrigger.TriggerCurrentWeather();
        return Task.CompletedTask;
    }

    public Task HandleAsync(CurrentForecastMessage eventMessage)
    {
        var forecast = eventMessage.CurrentWeather;
        CurrentWeatherRecord = new()
        {
            Date = forecast.DateTime,
            Temperature = forecast.Temperature
        };
        return Task.CompletedTask;
    }
}
