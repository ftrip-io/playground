using FluentValidation;

namespace ftrip.io.framework_playground.WeatherForecastRecords.UseCases.CreateWeatherForecastRecord
{
    public class CreateWeatherForecastRecordRequestValidator : AbstractValidator<CreateWeatherForecastRecordRequest>
    {
        public CreateWeatherForecastRecordRequestValidator()
        {
            RuleFor(request => request.Summary)
                .NotEmpty()
                .WithMessage("Summary should not be empty.");
        }
    }
}