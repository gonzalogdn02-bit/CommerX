using CommerX.Domain.Common.Exceptions;

namespace CommerX.Domain.Common.Exceptions;

public abstract class DomainException : Exception
{
    protected DomainException(string message) : base(message) { }
}