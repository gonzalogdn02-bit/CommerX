using CommerX.Application.Common.Results;
using CommerX.Application.Common.Validation;

namespace CommerX.Application.Common.Ports;

public abstract class BasePresenter<T> : IBaseOutputPort<T>
{
    protected OperationResult<T>? _result;

    public OperationResult<T>? Result => _result;

    public virtual Task HandleSuccessAsync(T response)
    {
        _result = OperationResult<T>.Ok(response);
        return Task.CompletedTask;
    }

    public virtual Task ValidationErrorsAsync(IReadOnlyList<ValidationError> errors)
    {
        _result = OperationResult<T>.Fail(errors.Select(e => e.ErrorMessage).ToList());
        return Task.CompletedTask;
    }

    public virtual Task HandleErrorAsync(string message)
    {
        _result = OperationResult<T>.Fail(message);
        return Task.CompletedTask;
    }
}