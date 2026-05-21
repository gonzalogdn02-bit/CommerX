using CommerX.Domain.Customers.Exceptions;
using CommerX.Domain.Common.ValueObjects;
using System.Text.RegularExpressions;

namespace CommerX.Domain.Customers.ValueObjects;

// Value Object que encapsula la validación de formato de email
public sealed record EmailAddress : ValueObject
{
    // Regex compilada: mejor rendimiento en llamadas repetidas
    private static readonly Regex EmailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
    public string Value { get; }
    private EmailAddress(string value) => Value = value;
    public static EmailAddress Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidEmailException(value ?? string.Empty);

        var normalized = value.Trim().ToLowerInvariant();

        if (!EmailRegex.IsMatch(normalized))
            throw new InvalidEmailException(normalized);

        return new EmailAddress(normalized);
    }

    public override string ToString() => Value;
}