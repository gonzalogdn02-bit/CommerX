using System;
using System.Text.RegularExpressions;

namespace CommerX.Domain.Common.ValueObjects;

public sealed class Email
{
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email no puede estar vacío.", nameof(email));

        var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(email, pattern, RegexOptions.CultureInvariant))
            throw new ArgumentException("Email con formato inválido.", nameof(email));

        return new Email(email.Trim());
    }

    public override string ToString() => Value;

    public override bool Equals(object? obj) =>
        obj is Email other && string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);

    public override int GetHashCode() => StringComparer.OrdinalIgnoreCase.GetHashCode(Value);
}