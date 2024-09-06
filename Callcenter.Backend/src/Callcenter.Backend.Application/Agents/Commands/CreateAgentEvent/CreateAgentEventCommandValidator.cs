using FluentValidation;

public class CreateAgentEventCommandValidator : AbstractValidator<CreateAgentEventCommand>
{
    public CreateAgentEventCommandValidator()
    {
        RuleFor(x => x.TimestampUtc)
            .GreaterThan(DateTime.UtcNow.AddHours(-1));
    }
}