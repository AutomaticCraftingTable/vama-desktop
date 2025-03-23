using Avalonia.Controls;
using VamaDesktop.ViewModels;

namespace VamaDesktop.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        DataContext = new MainWindowViewModel();
        InitializeComponent();
    }
}