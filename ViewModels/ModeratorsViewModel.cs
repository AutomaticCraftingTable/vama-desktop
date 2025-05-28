using Akavache;
using Avalonia.SimpleRouter;
using Flurl.Http;
using VamaDesktop.API.DTO.Errors;
using VamaDesktop.API.DTO.Requests;
using VamaDesktop.API.DTO.Responses;
using VamaDesktop.API.Utils;

namespace VamaDesktop.ViewModels;

public class ModeratorsViewModel(HistoryRouter<ViewModelBase> router) : ViewModelBase(router)
{
}