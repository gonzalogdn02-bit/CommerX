using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommerX.Domain.Common.ValueObjects;
using CommerX.Domain.Customers.Exceptions;

namespace CommerX.Domain.Customers.ValueObjects
{
    public sealed record DocumentNumber : ValueObject
    {
        public string Value { get; init; }

        private DocumentNumber()
        {
            Value = string.Empty;
        }

        private DocumentNumber(string value)
        {
            Value = value;
        }

        public static DocumentNumber Create(string documentNumber)
        {
            if (string.IsNullOrWhiteSpace(documentNumber))
                throw new InvalidDocumentNumberException(documentNumber ?? string.Empty);

            string normalizedDocumentNumber = documentNumber.Trim();

            return new DocumentNumber(normalizedDocumentNumber);
        }

        public static implicit operator DocumentNumber(string v)
        {
            return Create(v);
        }
    }
}