using System.Net;
using System.Text.Json;
using Diamond.Data.Weather.Contract.DataClasses;

namespace Diamond.Data.Weather.Http.OpenMeteo.Test;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class CurrentWeatherProjectionTests
{
    private readonly IHttpClientFactory _httpClientFactory = Substitute.For<IHttpClientFactory>();

    [Test]
    public async Task GetCurrentWeatherAsync_ValidResponse_ReturnsCurrentWeather()
    {
        // given
        var messageHandler = new MockHttpMessageHandler()
        {
            Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"{
                ""current"": {
                    ""temperature_2m"": 25.6,
                    ""time"": ""2024-01-01T12:00""
                },
                ""utc_offset_seconds"": 3600
            }")
            }
        };

        var sut = CreateSut(messageHandler);

        // when
        var result = await sut.GetCurrentWeatherAsync();

        // then
        using var scope = new AssertionScope();
        result.Should().NotBeNull();
        result.Temperature.Should().Be(25.6);
        result.DateTime.Should().Be(DateTimeOffset.Parse("2024-01-01T12:00+01:00"));
        messageHandler.Requests.Should().HaveCount(1);
        messageHandler.Requests[0].RequestUri!.ToString().Should()
            .Contain("latitude=51.0509")
            .And.Contain("longitude=13.7383")
            .And.Contain("current=temperature_2m");
    }

    [Test]
    public async Task GetCurrentWeatherAsync_InvalidResponse_ThrowsException()
    {
        // given
        var messageHandler = new MockHttpMessageHandler()
        {
            Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
        };
        var sut = CreateSut(messageHandler);

        // when
        var action = () => sut.GetCurrentWeatherAsync();

        // then
        await action.Should().ThrowAsync<HttpRequestException>();
    }

    [Test]
    public async Task GetCurrentWeatherAsync_MalformedJson_ThrowsException()
    {
        // given
        var messageHandler = new MockHttpMessageHandler()
        {
            Response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("invalid json")
            }
        };
        var sut = CreateSut(messageHandler);

        // when
        var action = () => sut.GetCurrentWeatherAsync();

        // then
        await action.Should().ThrowAsync<JsonException>();
    }

    private CurrentWeatherProjection CreateSut(HttpMessageHandler handler)
    {
        var httpClient = new HttpClient(handler);
        httpClient.BaseAddress = new Uri("http://localhost");
        _httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);
        return new(_httpClientFactory);
    }
}

public class MockHttpMessageHandler : HttpMessageHandler
{
    public HttpResponseMessage Response { get; set; } = new();
    public List<HttpRequestMessage> Requests { get; } = new();

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        Requests.Add(request);
        return Task.FromResult(Response);
    }
}
