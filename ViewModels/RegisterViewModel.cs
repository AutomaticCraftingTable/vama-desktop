using System;
using System.ComponentModel;
using Avalonia.SimpleRouter;
using VamaDesktop.API;
using VamaDesktop.API.DTO;
using VamaDesktop.API.DTO.Exceptions;
using VamaDesktop.API.Services;
using VamaDesktop.API.Utils;

namespace VamaDesktop.ViewModels;

public class RegisterViewModel : ViewModelBase
{
    private readonly Request<MessageResponse, RegisterError> _registerRequest = new AuthService().Register;
    public bool RegulationsAccepted { get; set; }
    
    private RegisterError _error = new();

    public RegisterError Error
    {
        get => _error;
        private set
        {
            _error = value; 
            OnPropertyChanged();
        }
    }

    public RegisterViewModel(HistoryRouter<ViewModelBase> router) : base(router)
    {
        _registerRequest.OnSuccess += _ => Router.GoTo<AdminPanelViewModel>();
        _registerRequest.OnError += error => Error = error;
    }

    public void Register()
    {
        if (RegulationsAccepted)
        {
            _registerRequest.Invoke();
        }
    }
}