using System.Net.Http;
using Avalonia.SimpleRouter;
using VamaDesktop.API.Utils;

namespace VamaDesktop.ViewModels;

public class CommentViewModel(HistoryRouter<ViewModelBase> router) : ViewModelBase(router)
{
    public int Id { get; set; }
    
    public void ReportComment()
    {
        RequestClient<object, object>.Post($"/api/comment/{Id}/report");
    }
}