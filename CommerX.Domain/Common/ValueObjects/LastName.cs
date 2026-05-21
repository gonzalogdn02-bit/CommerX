using CommerX.Domain.Common.ValueObjects;
using CommerX.Domain.Customers.Exceptions;

namespace CommerX.Domain.Customers.ValueObjects;

public sealed record LastName : ValueObject
{
    public string Value { get; init; }
    private LastName(string value) => Value = value;
    public static LastName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidLastNameException(value ?? string.Empty);

        var trimmedValue = value.Trim();

        if (trimmedValue.Length < 2 || trimmedValue.Length > 100)
            throw new InvalidLastNameException(trimmedValue);

        return new LastName(trimmedValue);
    }
    public override string ToString() => Value;
}