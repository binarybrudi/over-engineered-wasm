using Microsoft.AspNetCore.Components;

namespace Diamond.Ui.Weather.Widgets;

public partial class WeatherWidget
{
    protected override void OnAfterFirstRender()
    {
        base.OnAfterFirstRender();
        ViewModel.RequestCurrentWeatherForecast();
    }
}