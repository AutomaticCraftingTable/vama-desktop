using System.Collections.ObjectModel;
using Avalonia.SimpleRouter;
using VamaDesktop.API.Utils;
using VamaDesktop.Models.Get;

namespace VamaDesktop.ViewModels;

public class ModeratorsViewModel : RoutedModelBase
{
    public ModeratorsViewModel(HistoryRouter<ViewModelBase> router) : base(router)
    {
        var r = TheoryRequests.ListModerators();
        r.Actions.OnSuccess += body => ModeratorsModel = body;
        r.Actions.OnFinish += SetState;
        r.AsyncInvoke();
    }

    public ListModeratorsModel ModeratorsModel { get; set; }
}