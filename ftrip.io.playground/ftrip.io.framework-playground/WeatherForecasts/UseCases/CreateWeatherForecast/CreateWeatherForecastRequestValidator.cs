using FluentValidation;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.CreateWeatherForecast
{
    public class CreateWeatherForecastRecordRequestValidator : AbstractValidator<CreateWeatherForecastRequest>
    {
        public CreateWeatherForecastRecordRequestValidator()
        {
            RuleFor(request => request.Summary)
                .NotEmpty()
                .WithMessage("Summary should not be empty.");
        }
    }
}