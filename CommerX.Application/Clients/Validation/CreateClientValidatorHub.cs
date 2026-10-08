using CommerX.Application.Common.Validation;
using CommerX.Application.Clients.DTOs;
using CommerX.Application.Validation;

namespace CommerX.Application.Clients.Validation;

public class CreateClientValidationHub : IModelValidatorHub<CreateClientRequest>
{
    public IEnumerable<ValidationError> Validate(CreateClientRequest request)
    {
        var gFirstName = Guard.Against(request.FirstName, "FirstName")
            .NotNullOrEmpty().MinLength(2).MaxLength(100);

        var gLastName = Guard.Against(request.LastName, "LastName")
            .NotNullOrEmpty().MinLength(2).MaxLength(100);

        var gDocument = Guard.Against(request.Document, "Document")
            .NotNullOrEmpty().MinLength(7).MaxLength(8);

        var gEmail = Guard.Against(request.Email, "Email").NotNullOrEmpty()
            .InvalidEmail();

        var gPhone = Guard.Against(request.Phone, "Phone").NotNullOrEmpty()
            .MaxLength(20);

        var gAddress = Guard.Against(request.Address, "Address").NotNullOrEmpty()
            .MaxLength(200);

        var gBirthDate = Guard.Against(request.BirthDate.ToString(), "BirthDate")
            .NotNullOrEmpty("La fecha de nacimiento es requerida");

        return gFirstName.Errors
            .Concat(gLastName.Errors)
            .Concat(gDocument.Errors)
            .Concat(gEmail.Errors)
            .Concat(gPhone.Errors)
            .Concat(gAddress.Errors)
            .Concat(gBirthDate.Errors);
    }
}