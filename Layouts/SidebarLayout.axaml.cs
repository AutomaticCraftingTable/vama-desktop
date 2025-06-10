using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.SimpleRouter;
using Flurl.Http;
using VamaDesktop.API.DTO;
using VamaDesktop.API.DTO.Models.Error;
using VamaDesktop.API.DTO.Models.Success;
using VamaDesktop.API.Utils;
using VamaDesktop.ViewModels;

namespace VamaDesktop.Layouts;

public partial class SidebarLayout : ContentControl
{
    public static readonly StyledProperty<HistoryRouter<ViewModelBase>> RouterProperty =
        AvaloniaProperty.Register<SidebarLayout, HistoryRouter<ViewModelBase>>(nameof(Router));

    public HistoryRouter<ViewModelBase> Router
    {
        get => GetValue(RouterProperty);
        set => SetValue(RouterProperty, value);
    }

    public static readonly StyledProperty<int> IndexProperty = AvaloniaProperty.Register<SidebarLayout, int>(
        nameof(Index));

    public int Index
    {
        get => GetValue(IndexProperty);
        set => SetValue(IndexProperty, value);
    }

    public SidebarLayout() => InitializeComponent();

    private void GoUsers(object? sender, RoutedEventArgs e)
    {
        Router.GoTo<ProfilesViewModel>();
    }

    private void Logout(object? sender, RoutedEventArgs e)
    {
        var request = new RequestClient<MessageResponse, MessageError>(
            async client => await client
                .Request("/api/auth/logout")
                .PostAsync()
                .ReceiveJson<MessageResponse>());
        request.Invoke();
        Router.GoTo<LoginViewModel>();
    }

    private void GoModerators(object? sender, RoutedEventArgs e)
    {
        Router.GoTo<ModeratorsViewModel>();
    }

    private void GoReportAuthor(object? sender, RoutedEventArgs e)
    {
        Router.GoTo<ReportAuthorViewModel>();
    }

    private void GoReportArticle(object? sender, RoutedEventArgs e)
    {
        Router.GoTo<ReportArticleViewModel>();
    }

    private void GoReportComment(object? sender, RoutedEventArgs e)
    {
        Router.GoTo<ReportCommentViewModel>();
    }

    private void GoOwnActivity(object? sender, RoutedEventArgs e)
    {
        Router.GoTo<OwnActivityViewModel>();
    }

    private void GoAdminsActivity(object? sender, RoutedEventArgs e)
    {
        Router.GoTo<AdminsActivityViewModel>();
    }
}