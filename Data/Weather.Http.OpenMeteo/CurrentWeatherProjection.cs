using System.Text.Json;
using System.Web;
using Diamond.Data.Weather.Contract;
using Diamond.Data.Weather.Contract.DataClasses;
using Diamond.Data.Weather.Http.OpenMeteo.Dto;
using Diamond.Data.Weather.Http.OpenMeteo.Mapping;

namespace Diamond.Data.Weather.Http.OpenMeteo;

internal sealed class CurrentWeatherProjection : ICurrentWeatherProjection
{
    private readonly HttpClient _httpClient;

    public CurrentWeatherProjection(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient(Constants.HttpClient.OpenMeteoHttpClientName);
    }
    
    public async Task<CurrentWeather> GetCurrentWeatherAsync()
    {
        var relativePath = "v1/forecast";

        var queryParams = new Dictionary<string, string>
        {
            { "latitude", "51.0509" },
            { "longitude", "13.7383" },
            { "current", "temperature_2m,is_day" },
            { "timezone", "auto" },
            { "forecast_days", "1" },
            { "wind_speed_unit", "ms" },
            { "forecast_hours", "1" }
        };

        var queryString = HttpUtility.ParseQueryString(string.Empty);
        foreach (var param in queryParams)
        {
            queryString[param.Key] = param.Value;
        }

        var endpoint = $"{relativePath}?{queryString}";
        var jsonResult = await _httpClient.GetStringAsync(endpoint);
        
        var dto = JsonSerializer.Deserialize<CurrentWeatherDto>(jsonResult);
        return CurrentWeatherDtoMapper.MapToCurrentWeather(dto!);
    }
}