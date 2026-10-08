using CommerX.Application.Clients.DTOs;
using CommerX.Application.Clients.Ports;
using CommerX.InterfaceAdapter.Clients.Presenters;
using System;
using System.Threading.Tasks;

namespace CommerX.InterfaceAdapter.Clients.ViewModels
{
    public sealed class CreateClientViewModel
    {
        private readonly ICreateClientInputPort _useCase;
        private readonly CreateClientPresenter _presenter;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        public string Mensaje { get; private set; } = string.Empty;
        public bool EnCurso { get; private set; }

        public CreateClientViewModel(
            ICreateClientInputPort useCase,
            CreateClientPresenter presenter)
        {
            _useCase = useCase;
            _presenter = presenter;
        }

        public async Task GuardarAsync()
        {
            EnCurso = true;
            try
            {
                var request = new CreateClientRequest
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Document = Document,
                    Email = Email,
                    Phone = Phone,
                    Address = Address,
                    BirthDate = BirthDate
                };

                await _useCase.ExecuteAsync(request);

                Mensaje = _presenter.Result!.IsSuccess
                    ? $"Cliente '{FirstName} {LastName}' registrado correctamente."
                    : string.Join("; ", _presenter.Result.Errors);
            }
            finally
            {
                EnCurso = false;
            }
        }
    }
}