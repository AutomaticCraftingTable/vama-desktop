using System;
using Avalonia.Interactivity;
using VamaDesktop.ViewModels;

namespace VamaDesktop.Views.Components;

public partial class CommentView : ViewControl<CommentViewModel>
{
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