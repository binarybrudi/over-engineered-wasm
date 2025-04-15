using Diamond.Data.Weather.Contract;

namespace Diamond.Logic.Domain.Weather.Test;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class CurrentWeatherProviderTests
{
    private readonly ICurrentWeatherProjection _currentWeatherProjection = Substitute.For<ICurrentWeatherProjection>();

    [Test]
    public async Task ProvideCurrentAsync_HappyPath_ReturnsCurrentSendsMessage()
    {
        // given
        var sut = CreateSut();

        // when
        var result = await sut.ProvideCurrentAsync();

        // then
        using var scope = new AssertionScope();
        result.Temperature.Should().Be(30);
        result.DateTime.Should().BeBefore(DateTimeOffset.UtcNow);
    }


    [Test]
    public async Task ProvideCurrentAsync_HappyPath_SendsMessage()
    {
        // given
        var sut = CreateSut();

        // when
        var result = await sut.ProvideCurrentAsync();

        // then
    }

    private CurrentWeatherProvider CreateSut()
    {
        return new CurrentWeatherProvider(_currentWeatherProjection);
    }
}
