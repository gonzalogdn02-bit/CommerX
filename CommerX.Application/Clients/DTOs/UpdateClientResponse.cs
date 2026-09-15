using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerX.Application.Clients.DTOs;

public sealed class UpdateClientResponse
{
    public Guid CustomerId { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public string Address { get; init; }
    public DateOnly BirthDate { get; init; }

    public UpdateClientResponse(
        Guid customerId,
        string email,
        string phone,
        string address,
        DateOnly birthDate)
    {
        CustomerId = customerId;
        Email = email;
        Phone = phone;
        Address = address;
        BirthDate = birthDate;
    }
}