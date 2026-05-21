using CommerX.Domain.Common.ValueObjects;
using CommerX.Domain.Customers.Exceptions;
using System.Linq;

namespace CommerX.Domain.Customers.ValueObjects;
public sealed record Phone : ValueObject
{
    public string Value { get; init; }
    private Phone(string value) => Value = value;
    public static Phone Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidPhoneException(value ?? string.Empty);

        var trimmedValue = value.Trim();

        if (trimmedValue.Length < 7 || trimmedValue.Length > 15 || !trimmedValue.All(char.IsDigit))
            throw new InvalidPhoneException(trimmedValue);

        return new Phone(trimmedValue);
    }
    public override string ToString() => Value;
}