using ftrip.io.framework_playground.WeatherForecasts.Domain;
using MediatR;
using System.Collections.Generic;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.ReadWeatherForecast
{
    public class ReadWeatherForecastRequest : IRequest<IEnumerable<WeatherForecast>>
    {
    }
}