using CommerX.Domain.Common.Exceptions;
using CommerX.Domain.Customers.Exceptions;

namespace CommerX.Domain.Customers.Exceptions;

public sealed class InvalidFirstNameException : DomainException
{
    public InvalidFirstNameException(string value)
        : base($"El nombre '{value}' no es válido. Debe tener entre 2 y 100 caracteres.") { }
}