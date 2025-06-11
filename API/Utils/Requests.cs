using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using VamaDesktop.API.DTO.Models.Body;
using VamaDesktop.API.DTO.Models.Error;
using VamaDesktop.API.DTO.Models.Success;
using VamaDesktop.Models;
using VamaDesktop.Models.Get;

namespace VamaDesktop.API.Utils;

public static class Requests
{
    public static RequestPayload<
        AuthResponse,
        CommonErrorRecord<LoginError>,
        AuthCredentials
    > AuthLogin(AuthCredentials body)
    {
        return new(
            method: HttpMethod.Post,
            url: "/api/auth/login",
            body: body
        );
    }

    public static RequestPayload<
        ListModeratorsModel,
        object
    > ListModerators()
    {
        return new(
            method: HttpMethod.Get,
            url: "/api/list/moderators"
        );
    }

    public static RequestPayload<
        ObservableCollection<ListActivitiesModel>,
        object
    > Activities()
    {
        return new(
            method: HttpMethod.Get,
            url: "/api/activities"
        );
    }

    public static RequestPayload<
        ObservableCollection<ListActivitiesModel>,
        object
    > ActivitiesAdmins()
    {
        return new(
            method: HttpMethod.Get,
            url: "/api/activities/admins"
        );
    }

    public static RequestPayload<
        ListProfilesData,
        object
    > ListProfiles()
    {
        return new(
            method: HttpMethod.Get,
            url: "/api/list/profiles"
        );
    }

    public static RequestPayload<
        object,
        object
    > ListReportsProfiles()
    {
        return new(
            method: HttpMethod.Get,
            url: "/api/list/reports/profiles"
        );
    }

    public static RequestPayload<
        object,
        object
    > ListReportsComments()
    {
        return new(
            method: HttpMethod.Get,
            url: "/api/list/reports/comments"
        );
    }

    public static RequestPayload<
        object,
        object
    > ListReportsArticles()
    {
        return new(
            method: HttpMethod.Get,
            url: "/api/list/reports/articles"
        );
    }

    public static RequestPayload<
        object,
        object
    > DeleteNote(int id)
    {
        return new(
            method: HttpMethod.Delete,
            url: $"/api/note/{id}"
        );
    }

    public static RequestPayload<
        object,
        object
    > DeleteAccount(int accountId)
    {
        return new(
            method: HttpMethod.Delete,
            url: $"/api/account/{accountId}"
        );
    }

    public static RequestPayload<
        object,
        object
    > BanAccount(int accountId)
    {
        return new(
            method: HttpMethod.Post,
            url: $"/api/account/{accountId}/ban"
        );
    }

    public static RequestPayload<
        object,
        object
    > UnbanAccount(int accountId)
    {
        return new(
            method: HttpMethod.Delete,
            url: $"/api/account/{accountId}/ban"
        );
    }

    public static RequestPayload<
        object,
        object,
        Dictionary<string, string>
    > ChangeRole(int accountId, Dictionary<string, string> body)
    {
        return new(
            method: HttpMethod.Post,
            url: $"/api/account/{accountId}/role",
            body: body
        );
    }


    public static RequestPayload<
        object,
        object
    > DeleteArticle(int artcileId)
    {
        return new(
            method: HttpMethod.Delete,
            url: $"/api/article/{artcileId}"
        );
    }

    public static RequestPayload<
        object,
        object
    > UnbanArticle(int artcileId)
    {
        return new(
            method: HttpMethod.Delete,
            url: $"/api/article/{artcileId}/ban"
        );
    }

    public static RequestPayload<
        object,
        object
    > BanArticle(int artcileId)
    {
        return new(
            method: HttpMethod.Post,
            url: $"/api/article/{artcileId}/ban"
        );
    }

    public static RequestPayload<
        object,
        object
    > DeleteArticleReport(int artcileId)
    {
        return new(
            method: HttpMethod.Delete,
            url: $"/api/article/{artcileId}/report"
        );
    }

    public static RequestPayload<
        object,
        object
    > UnbanComment(int commentId)
    {
        return new(
            method: HttpMethod.Delete,
            url: $"/api/comment/{commentId}/ban"
        );
    }

    public static RequestPayload<
        object,
        object,
        Dictionary<string, string>
    > BanComment(int commentId)
    {
        return new(
            method: HttpMethod.Post,
            url: $"/api/comment/{commentId}/ban",
            body: new Dictionary<string, string>
                { { "content", $"Komentarz #{commentId} zablokowany przez administratora" } }
        );
    }

    public static RequestPayload<
        object,
        object,
        Dictionary<string, string>
    > ReportComment(int id)
    {
        return new(
            method: HttpMethod.Post,
            url: $"/api/comment/{id}/report",
            body: new Dictionary<string, string> { { "content", $"Zgłoszony komentarz {id}" } }
        );
    }

    public static RequestPayload<
        object,
        object
    > ReportArticle(int id)
    {
        return new(
            method: HttpMethod.Post,
            url: $"/api/article/{id}/report"
        );
    }

    public static RequestPayload<
        object,
        object
    > DeleteProfileReport(string nickname)
    {
        return new(
            method: HttpMethod.Delete,
            url: $"/api/profile/{nickname}/report"
        );
    }
}