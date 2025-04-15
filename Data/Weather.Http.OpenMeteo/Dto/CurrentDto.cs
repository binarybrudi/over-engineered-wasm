using System.Text.Json.Serialization;

namespace Diamond.Data.Weather.Http.OpenMeteo.Dto;

internal sealed class CurrentDto
{
    [JsonPropertyName("time")]
    public string Time { get; init; } = string.Empty;
    [JsonPropertyName("interval")]
    public int Interval { get; init; }
    [JsonPropertyName("temperature_2m")]
    public double Temperature2m { get; init; }
    [JsonPropertyName("is_day")]
    public int IsDay { get; init; }
}
