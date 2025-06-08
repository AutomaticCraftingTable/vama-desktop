using Avalonia.SimpleRouter;

namespace VamaDesktop.ViewModels;

public class RoutedModelBase(HistoryRouter<ViewModelBase> router) : ViewModelBase
{
    public HistoryRouter<ViewModelBase> Router { get; } = router;
}