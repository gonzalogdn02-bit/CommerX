using System.Text.RegularExpressions;

namespace CommerX.Application.Common.Validation;

public class GuardBuilderString : GuardBuilderBase<GuardBuilderString>
{
    private readonly string? _value;

    public GuardBuilderString(string? value, string paramName)
        : base(paramName) => _value = value;

    public GuardBuilderString NotNullOrEmpty(string? mensaje = null)
    {
        if (string.IsNullOrWhiteSpace(_value))
        {
            AddError(mensaje ?? $"El campo '{_paramName}' es requerido.");
        }
        return this;
    }

    public GuardBuilderString MinLength(int min, string? mensaje = null)
    {
        if (_value?.Length < min)
        {
            AddError(mensaje ?? $"'{_paramName}' debe tener al menos {min} caracteres.");
        }
        return this;
    }

    public GuardBuilderString MaxLength(int max, string? mensaje = null)
    {
        if (_value?.Length > max)
        {
            AddError(mensaje ?? $"'{_paramName}' no puede superar {max} caracteres.");
        }
        return this;
    }

    public GuardBuilderString InvalidEmail(string? mensaje = null)
    {
        var regex = new Regex(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
        if (string.IsNullOrWhiteSpace(_value) || !regex.IsMatch(_value))
        {
            AddError(mensaje ?? $"'{_paramName}' no es un correo válido.");
        }
        return this;
    }
}