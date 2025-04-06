using FluentAssertions;
using FluentAssertions.Execution;

namespace Diamond.Logic.Domain.Weather.Tests;

public class WeatherForecastProviderTests
{
    [Test]
    public void Test1()
    {
        // given
        var sut = CreateSut();
        
        // when
        var result = sut.ProvideCurrentAsync().Result;
        
        // then
        using var scope = new AssertionScope();
        result.Temperature.Should().Be(30);
    }

    private WeatherForecastProvider CreateSut()
    {
        return new WeatherForecastProvider();
    }
}