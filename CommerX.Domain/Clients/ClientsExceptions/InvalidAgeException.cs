using CommerX.Domain.Common.Exceptions;
using CommerX.Domain.Customers.Exceptions;

namespace CommerX.Domain.Customers.Exceptions;

public sealed class InvalidAgeException : DomainException
{
    public InvalidAgeException(DateOnly birthDate)
        : base($"La fecha de nacimiento '{birthDate:dd/MM/yyyy}' es inválida o no cumple el requisito de mayoría de edad.") { }
}
