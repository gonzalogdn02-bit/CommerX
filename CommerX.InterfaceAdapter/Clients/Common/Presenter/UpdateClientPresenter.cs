using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommerX.InterfaceAdapter.Clients.Presenters;

public class UpdateClientPresenter
{
    public bool IsSuccess { get; private set; }
    public string? Message { get; private set; }

    public void HandleSuccess()
    {
        IsSuccess = true;
        Message = "Cliente actualizado correctamente.";
    }

    public void HandleError(string errorMessage)
    {
        IsSuccess = false;
        Message = errorMessage;
    }
}