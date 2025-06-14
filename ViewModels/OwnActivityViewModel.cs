using System.Collections.ObjectModel;
using Avalonia.SimpleRouter;
using VamaDesktop.API.Utils;
using VamaDesktop.Models;

namespace VamaDesktop.ViewModels;

public class OwnActivityViewModel : RoutedModelBase
{
    public OwnActivityViewModel(HistoryRouter<ViewModelBase> router) : base(router)
    {
        var r = Requests.Activities();
        r.Actions.OnSuccess += body => OwnActivitiesModel = body;
        r.Actions.OnFinish += SetState;
        r.AsyncInvoke();
    }

    public ObservableCollection<ListActivitiesModel> OwnActivitiesModel { get; set; }
}