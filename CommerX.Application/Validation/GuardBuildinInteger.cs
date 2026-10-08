using CommerX.Application.Common.Validation;

namespace CommerX.Application.Validation
{
    internal class GuardBuildinInteger : GuardBuilderBase<GuardBuildinInteger>
    {
        private readonly int _value;

        public GuardBuildinInteger(int value, string paramName) : base(paramName)
        {
            _value = value;
        }

        public GuardBuildinInteger NotZero()
        {
            if (_value == 0)
            {
                AddError("Value cannot be zero.");
            }
            return this;
        }

        public GuardBuildinInteger NotNegative()
        {
            if (_value < 0)
            {
                AddError("Value cannot be negative.");
            }
            return this;
        }

        public GuardBuildinInteger GreaterThan(int min)
        {
            if (_value <= min)
            {
                AddError($"Value must be greater than {min}.");
            }
            return this;
        }

        public GuardBuildinInteger GreaterThanOrEqual(int min)
        {
            if (_value < min)
            {
                AddError($"Value must be greater than or equal to {min}.");
            }
            return this;
        }

        public GuardBuildinInteger LessThan(int max)
        {
            if (_value >= max)
            {
                AddError($"Value must be less than {max}.");
            }
            return this;
        }

        public GuardBuildinInteger LessThanOrEqual(int max)
        {
            if (_value > max)
            {
                AddError($"Value must be less than or equal to {max}.");
            }
            return this;
        }
    }
}