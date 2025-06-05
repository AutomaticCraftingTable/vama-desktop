using System;
using System.Net.Http;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using VamaDesktop.API.Utils;
using VamaDesktop.ViewModels;

namespace VamaDesktop.Views;

public partial class CommentView : ViewControl<CommentViewModel>
{
    public CommentView()
    {
        InitializeComponent();
    }
    private void ReportComment(object? sender, RoutedEventArgs e)
    {
        ViewModel.ReportComment();
        
    }
    private void BanComment(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine("aoristharyshtluy");
    }
}