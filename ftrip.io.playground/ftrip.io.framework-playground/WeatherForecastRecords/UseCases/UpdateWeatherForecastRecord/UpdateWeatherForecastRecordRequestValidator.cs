using FluentValidation;

namespace ftrip.io.framework_playground.WeatherForecastRecords.UseCases.UpdateWeatherForecastRecord
{
    public class UpdateWeatherForecastRecordRequestValidator : AbstractValidator<UpdateWeatherForecastRecordRequest>
    {
        public UpdateWeatherForecastRecordRequestValidator()
        {
            RuleFor(request => request.Summary)
                .NotEmpty()
                .WithMessage("Summary should not be empty.");
        }
    }
}