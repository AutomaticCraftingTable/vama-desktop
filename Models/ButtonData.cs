using CommunityToolkit.Mvvm.Input;

namespace VamaDesktop.Models;

public class ButtonData
{
    public object Text { get; set; }
    public RelayCommand Click { get; set; }
}