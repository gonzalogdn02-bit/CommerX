using CommerX.Domain.Common.Exceptions;
using CommerX.Domain.Customers.Exceptions;

namespace CommerX.Domain.Customers.Exceptions;

public sealed class InvalidPhoneException : DomainException
{
    public InvalidPhoneException(string value)
        : base($"El teléfono '{value}' no es válido. Solo dígitos, entre 7 y 15 caracteres.") { }
}