using FluentValidation;

namespace ftrip.io.framework_playground.WeatherForecasts.UseCases.UpdateWeatherForecast
{
    public class UpdateWeatherForecastRecordRequestValidator : AbstractValidator<UpdateWeatherForecastRequest>
    {
        public UpdateWeatherForecastRecordRequestValidator()
        {
            RuleFor(request => request.Summary)
                .NotEmpty()
                .WithMessage("Summary should not be empty.");
        }
    }
}