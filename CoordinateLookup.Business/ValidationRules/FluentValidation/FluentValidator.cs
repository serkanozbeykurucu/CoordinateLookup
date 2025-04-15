using FluentValidation;
using FluentValidation.Results;

namespace CoordinateLookup.Business.ValidationRules.FluentValidation
{
    public class FluentValidator<T> : IValidator<T>
    {
        private readonly IValidator<T> _validator;

        public FluentValidator(IValidator<T> validator)
        {
            _validator = validator;
        }
        public bool CanValidateInstancesOfType(Type type)
        {
            return typeof(T).IsAssignableFrom(type);
        }
        public IValidatorDescriptor CreateDescriptor()
        {
            return _validator.CreateDescriptor();
        }

        public ValidationResult Validate(T instance)
        {
            return _validator.Validate(instance);
        }

        public ValidationResult Validate(IValidationContext context)
        {
            return _validator.Validate(context);
        }

        public async Task<ValidationResult> ValidateAsync(T instance, CancellationToken cancellation = default)
        {
            return await _validator.ValidateAsync(instance, cancellation);
        }

        public async Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = default)
        {
            return await _validator.ValidateAsync(context, cancellation);
        }
    }
}