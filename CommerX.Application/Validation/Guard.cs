using CommerX.Application.Common.Validation;

namespace CommerX.Application.Validation
{
    internal static class Guard
    {
        public static GuardBuilderString Against(string? value, string paramName)
            => new GuardBuilderString(value, paramName);

        public static GuardBuildinInteger Against(int value, string paramName)
            => new GuardBuildinInteger(value, paramName);
    }
}