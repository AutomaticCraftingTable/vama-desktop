using System.Reflection;
using Avalonia.SimpleRouter;
using CommunityToolkit.Mvvm.ComponentModel;

namespace VamaDesktop.ViewModels;

public class ViewModelBase(HistoryRouter<ViewModelBase> router) : ObservableObject
{
    public HistoryRouter<ViewModelBase> Router { get; } = router;
    
    protected void SetState()
    {
        var props = GetType().GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
        foreach (var prop in props)
        {
            OnPropertyChanged(prop.Name);
        }
    }
}