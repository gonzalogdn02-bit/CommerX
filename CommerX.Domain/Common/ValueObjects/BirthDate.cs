using CommerX.Domain.Common.ValueObjects;
using CommerX.Domain.Customers.Exceptions;

namespace CommerX.Domain.Customers.ValueObjects;

public sealed record BirthDate : ValueObject
{
    public DateOnly Value { get; init; }

    private BirthDate(DateOnly value) => Value = value;

    public static BirthDate Create(DateOnly date)
    {
        if (date == default)
            throw new InvalidAgeException(date);

        var today = DateOnly.FromDateTime(DateTime.Today);

        if (date >= today)
            throw new InvalidAgeException(date);

        var age = today.Year - date.Year;
        if (date > today.AddYears(-age)) age--;

        if (age < 18)
            throw new InvalidAgeException(date);

        return new BirthDate(date);
    }
}