using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.SimpleRouter;
using VamaDesktop.API.DTO.Base;
using VamaDesktop.API.Utils;
using VamaDesktop.Models;
using VamaDesktop.Models.Get;

namespace VamaDesktop.ViewModels;

public class ProfilesViewModel : RoutedModelBase
{
    public ProfilesViewModel(HistoryRouter<ViewModelBase> router) : base(router)
    {
        var r = Requests.ListProfiles();
        r.Actions.OnSuccess += profiles => ProfilesModel = profiles;
        r.Actions.OnFinish += SetState;
        r.AsyncInvoke();
    }

    public ListProfilesData ProfilesModel { get; set; }
}