using CommerX.Domain.Common.Entities;
using CommerX.Domain.Common.ValueObjects;
using CommerX.Domain.Customers.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerX.Domain.Clients.Entities
{
    public class Client : BaseEntity
    {
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public DocumentNumber DocumentNumber { get; private set; }
        public EmailAddress Email { get; private set; }
        public Phone Phone { get; private set; }
        public Address Address { get; private set; }
        protected Client() { }
        private Client(string firstName, string lastName, string documentNumber, string email, string phone, string address)
        {
            FirstName = FirstName.Create(firstName);
            LastName = LastName.Create(lastName);
            DocumentNumber = DocumentNumber.Create(documentNumber);
            Email = EmailAddress.Create(email);
            Phone = Phone.Create(phone);
            Address = Address.Create(address);
        }

        public static Client Create(string firstName, string lastName, string documentNumber, string email, string phone, string address, DateOnly birthDate)
        {
            return new Client(firstName, lastName, documentNumber, email, phone, address);
        }
    }
}