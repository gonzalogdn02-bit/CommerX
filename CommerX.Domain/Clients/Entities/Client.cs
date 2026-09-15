using CommerX.Domain.Common.Entities;
using CommerX.Domain.Common.ValueObjects;
using CommerX.Domain.Customers.ValueObjects;
using Xamarin.Essentials;
using Email = CommerX.Domain.Common.ValueObjects.Email;

namespace CommerX.Domain.Clients.Entities;

public class Client : BaseEntity
{
    public DateOnly BirthDate { get; private set; }
    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public DocumentNumber DocumentNumber { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Phone Phone { get; private set; } = null!;
    public Address Address { get; private set; } = null!;

    protected Client() { }

    private Client(
        string firstName,
        string lastName,
        string documentNumber,
        string email,
        string phone,
        string address,
        DateOnly birthDate)
    {
        FirstName = FirstName.Create(firstName);
        LastName = LastName.Create(lastName);
        DocumentNumber = DocumentNumber.Create(documentNumber);
        Email = Email.Create(email);
        Phone = Phone.Create(phone);
        Address = Address.Create(address);
        BirthDate = birthDate;
    }

    public static Client Create(
        string firstName,
        string lastName,
        string documentNumber,
        string email,
        string phone,
        string address,
        DateOnly birthDate) =>
        new Client(firstName, lastName, documentNumber, email, phone, address, birthDate);

    public void Update(string email, string phone, string address, DateOnly birthDate)
    {
        Email = Email.Create(email);
        Phone = Phone.Create(phone);
        Address = Address.Create(address);
        BirthDate = birthDate;
    }
}