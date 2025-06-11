using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.SimpleRouter;
using VamaDesktop.API.DTO.Base;
using VamaDesktop.API.Utils;
using VamaDesktop.Models;
using VamaDesktop.Models.Pages;

namespace VamaDesktop.ViewModels;

public class ProfilesViewModel : RoutedModelBase
{
    public ProfilesViewModel(HistoryRouter<ViewModelBase> router) : base(router)
    {
        var r = TheoryRequests.ListProfiles();
        r.Actions.OnSuccess += profiles => ProfilesModel = profiles;
        r.AsyncInvoke();
    }

    public ListProfilesData ProfilesModel { get; set; }
}