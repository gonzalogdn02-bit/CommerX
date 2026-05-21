using CommerX.Domain.Common.ValueObjects;
using CommerX.Domain.Customers.Exceptions;

namespace CommerX.Domain.Customers.ValueObjects;

public sealed record Address : ValueObject
{
    public string Value { get; init; }

    private Address(string value) => Value = value;

    public static Address Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidAddressException(value ?? string.Empty);

        var trimmedValue = value.Trim();

        if (trimmedValue.Length < 5 || trimmedValue.Length > 200)
            throw new InvalidAddressException(trimmedValue);

        return new Address(trimmedValue);
    }
}