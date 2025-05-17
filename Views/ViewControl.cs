using Avalonia.Controls;


namespace VamaDesktop.Views;
public class ViewControl<T>: UserControl
{
    protected T? ViewModel => (T?) DataContext;
}
