using System.Text.Json.Serialization;

namespace Diamond.Data.Weather.Http.OpenMeteo.Dto;

internal sealed record CurrentWeatherDto
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; init; }
    [JsonPropertyName("longitude")]
    public double Longitude { get; init; }
    [JsonPropertyName("generationtime_ms")]
    public double GenerationtimeMs { get; init; }
    [JsonPropertyName("utc_offset_seconds")]
    public int UtcOffsetSeconds { get; init; }
    [JsonPropertyName("timezone")]
    public string Timezone { get; init; } = string.Empty;
    [JsonPropertyName("timezone_abbreviation")]
    public string TimezoneAbbreviation { get; init; } = string.Empty;
    [JsonPropertyName("elevation")]
    public double Elevation { get; init; }
    [JsonPropertyName("current_units")]
    public CurrentUnitsDto CurrentUnits { get; init; } = new();
    [JsonPropertyName("current")]
    public CurrentDto Current { get; init; } = new();
}
