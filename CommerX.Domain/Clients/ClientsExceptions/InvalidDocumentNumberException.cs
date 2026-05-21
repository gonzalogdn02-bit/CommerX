using CommerX.Domain.Common.Exceptions;
using CommerX.Domain.Customers.Exceptions;

namespace CommerX.Domain.Customers.Exceptions;
public sealed class InvalidDocumentNumberException : DomainException
{
    public InvalidDocumentNumberException(string value)
        : base($"El número de documento '{value}' no es válido.") { }
}