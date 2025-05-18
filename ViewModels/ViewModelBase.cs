using Avalonia.SimpleRouter;
using CommunityToolkit.Mvvm.ComponentModel;

namespace VamaDesktop.ViewModels;

public class ViewModelBase(HistoryRouter<ViewModelBase> router) : ObservableObject
{
    public HistoryRouter<ViewModelBase> Router { get; } = router;
}