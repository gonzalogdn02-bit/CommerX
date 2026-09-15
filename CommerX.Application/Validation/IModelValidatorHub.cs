namespace CommerX.Application.Common.Validation;

public interface IModelValidatorHub<TModel>
{
    IEnumerable<ValidationError> Validate(TModel model);
}