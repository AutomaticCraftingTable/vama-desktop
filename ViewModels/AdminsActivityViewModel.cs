using System.Collections.ObjectModel;
using Avalonia.SimpleRouter;
using VamaDesktop.API.Utils;
using VamaDesktop.Models;

namespace VamaDesktop.ViewModels;

public class AdminsActivityViewModel : RoutedModelBase
{
    public AdminsActivityViewModel(HistoryRouter<ViewModelBase> router) : base(router)
    {
        var r = Requests.ActivitiesAdmins();
        r.Actions.OnSuccess += body => AdminsActivitiesModel = body;
        r.Actions.OnFinish += SetState;
        r.AsyncInvoke();
    }
    
    public ObservableCollection<ListActivitiesModel> AdminsActivitiesModel { get; set; }
}