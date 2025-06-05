using Akavache;
using Avalonia.SimpleRouter;
using Flurl.Http;
using VamaDesktop.API.Utils;

namespace VamaDesktop.ViewModels;

public class NotesViewModel(HistoryRouter<ViewModelBase> router) : ViewModelBase(router)
{
}