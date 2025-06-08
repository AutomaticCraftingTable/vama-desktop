using System;
using System.Collections.Generic;
using System.Windows.Input;
using Avalonia;
using Avalonia.Interactivity;
using VamaDesktop.ViewModels;

namespace VamaDesktop.Views.Components;

public interface IMyButtonItem
{
    public string Content { get; set; }
    public ICommand Click { get; set; }
}

public partial class CommentView : ViewControl<CommentViewModel>
{
    public static readonly StyledProperty<IList<IMyButtonItem>> ItemsProperty =
        AvaloniaProperty.Register<CommentView, IList<IMyButtonItem>>(nameof(Items));

    public IList<IMyButtonItem> Items
    {
        get => GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }
    
    public CommentView()
    {
        InitializeComponent();
    }
    private void ReportComment(object? sender, RoutedEventArgs e)
    {
        // ViewModel.ReportComment();
    }
    private void BanComment(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine("aoristharyshtluy");
    }
}