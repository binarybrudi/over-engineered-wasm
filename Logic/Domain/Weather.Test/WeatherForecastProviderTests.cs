using Brudibytes.Core.EventBus.Contract;
using Diamond.Logic.Domain.Weather.Contract.Messaging;
using FluentAssertions.Execution;

namespace Diamond.Logic.Domain.Weather.Tests;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
public class WeatherForecastProviderTests
{
    private readonly IEventBus _eventBus = Substitute.For<IEventBus>();

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
        await _eventBus.Received(1).PublishAsync(Arg.Any<CurrentForecastMessage>());
    }

    private WeatherForecastProvider CreateSut()
    {
        return new WeatherForecastProvider(_eventBus);
    }
}