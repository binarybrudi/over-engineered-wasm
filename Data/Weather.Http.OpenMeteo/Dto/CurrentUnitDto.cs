using System.Text.Json.Serialization;

namespace Diamond.Data.Weather.Http.OpenMeteo.Dto;

internal sealed class CurrentUnitsDto
{
    [JsonPropertyName("time")]
    public string? Time { get; init; }
    [JsonPropertyName("interval")]
    public string? Interval { get; init; }
    [JsonPropertyName("temperature_2m")]
    public string? Temperature2m { get; init; }
    [JsonPropertyName("is_day")]
    public string? IsDay { get; init; }
}
