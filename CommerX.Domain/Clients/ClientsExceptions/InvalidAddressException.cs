using CommerX.Domain.Common.Exceptions;
using CommerX.Domain.Customers.Exceptions;

namespace CommerX.Domain.Customers.Exceptions;

public sealed class InvalidAddressException : DomainException
{
    public InvalidAddressException(string value)
        : base($"La dirección '{value}' no es válida. Debe tener entre 5 y 200 caracteres.") { }
}