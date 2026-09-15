using CommerX.Application.Common.Validation;

namespace CommerX.Application.Common.Ports;

public interface IBaseOutputPort<T>
{
    Task HandleSuccessAsync(T response);
    Task ValidationErrorsAsync(IReadOnlyList<ValidationError> errors);
    Task HandleErrorAsync(string message);
}