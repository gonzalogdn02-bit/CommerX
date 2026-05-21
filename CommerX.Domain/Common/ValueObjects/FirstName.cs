using CommerX.Domain.Common.ValueObjects;
using CommerX.Domain.Customers.Exceptions;

namespace CommerX.Domain.Customers.ValueObjects;

public sealed record FirstName : ValueObject
{
    public string Value { get; init; }
    private FirstName(string value) => Value = value;

    public static FirstName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidFirstNameException(value ?? string.Empty);
        var trimmedValue = value.Trim();

        if (trimmedValue.Length < 2 || trimmedValue.Length > 100)
            throw new InvalidFirstNameException(trimmedValue);

        return new FirstName(trimmedValue);
    }
    public override string ToString() => Value;

    public static implicit operator FirstName(string v)
    {
        return Create(v);
    }
}