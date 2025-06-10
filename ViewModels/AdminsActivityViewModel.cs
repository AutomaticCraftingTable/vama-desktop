using Avalonia.SimpleRouter;
using VamaDesktop.API.Utils;

namespace VamaDesktop.ViewModels;

public class AdminsActivityViewModel : RoutedModelBase
{
    public AdminsActivityViewModel(HistoryRouter<ViewModelBase> router) : base(router)
    {
        FetchAdminsActivity();
    }

    public void FetchAdminsActivity()
    {
        var r = TheoryRequests.ActivitiesAdmin();
        _ = Theory.Request(r);
    }
    
}