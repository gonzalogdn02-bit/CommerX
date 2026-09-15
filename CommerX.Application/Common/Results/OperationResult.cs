namespace CommerX.Application.Common.Results;

public sealed class OperationResult<T>
{
    private OperationResult(bool isSuccess, T? value, IReadOnlyList<string> errors)
    {
        IsSuccess = isSuccess;
        Value = value;
        Errors = errors;
    }

    public bool IsSuccess { get; }
    public T? Value { get; }
    public IReadOnlyList<string> Errors { get; }

    public static OperationResult<T> Ok(T value)
        => new(true, value, Array.Empty<string>());

    public static OperationResult<T> Fail(IReadOnlyList<string> errors)
        => new(false, default, errors);

    public static OperationResult<T> Fail(string error)
        => new(false, default, new[] { error });
}