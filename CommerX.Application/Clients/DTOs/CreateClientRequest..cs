using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerX.Application.Clients.DTOs;

public class CreateClientRequest
{
    public required string FullName { get; init; }
    public required string LastName { get; init; }
    public required string Document { get; init; }
    public required string Email { get; init; }
    public required string Phone { get; init; }
    public required string Address { get; init; }
    public required DateOnly BirthDate { get; init; }
}