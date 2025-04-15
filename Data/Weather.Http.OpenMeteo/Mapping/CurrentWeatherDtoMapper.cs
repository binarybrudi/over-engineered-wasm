using Diamond.Data.Weather.Contract.DataClasses;
using Diamond.Data.Weather.Http.OpenMeteo.Dto;

namespace Diamond.Data.Weather.Http.OpenMeteo.Mapping;

internal static class CurrentWeatherDtoMapper
{
    internal static CurrentWeather MapToCurrentWeather(CurrentWeatherDto dto) => new()
    {
        DateTime = GetDateTimeOffsetFromCurrentWeather(dto),
        IsDay = dto.Current.IsDay > 0,
        Temperature = dto.Current.Temperature2m
    };

    private static DateTimeOffset GetDateTimeOffsetFromCurrentWeather(CurrentWeatherDto dto)
    {
        var dateTime = DateTime.Parse(dto.Current.Time, null, System.Globalization.DateTimeStyles.RoundtripKind);
        var offset = TimeSpan.FromSeconds(dto.UtcOffsetSeconds);
        return new DateTimeOffset(dateTime, offset);
    }
}
