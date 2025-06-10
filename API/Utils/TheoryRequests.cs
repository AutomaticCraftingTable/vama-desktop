using System.Net.Http;
using System.Threading.Tasks;
using VamaDesktop.API.DTO.Models.Body;
using VamaDesktop.API.DTO.Models.Error;
using VamaDesktop.API.DTO.Models.Success;

namespace VamaDesktop.API.Utils;

public static class TheoryRequests
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
        object,
        object,
        object
    > ActivitiesAdmin()
    {
        return new(
            method: HttpMethod.Get,
            url: "/api/activities/admins"
        );
    }

    public static RequestPayload<
        object,
        object,
        object
    > ListModerators()
    {
        return new(
            method: HttpMethod.Get,
            url: "/api/list/moderators"
        );
    }

    public static RequestPayload<
        object,
        object,
        object
    > Activities()
    {
        return new(
            method: HttpMethod.Get,
            url: "/api/activities"
        );
    }

    public static RequestPayload<
        object,
        object,
        object
    > ActivitiesAdmins()
    {
        return new(
            method: HttpMethod.Get,
            url: "/api/activities/admins"
        );
    }

    public static RequestPayload<
        object,
        object,
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
        object,
        object
    > DeleteNote(int articletId)
    {
        return new(
            method: HttpMethod.Delete,
            url: $"/api/article/{articletId}/note"
        );
    }

    public static RequestPayload<
        object,
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
        object
    > ChangeRole(int accountId)
    {
        return new(
            method: HttpMethod.Patch,
            url: $"/api/account/{accountId}/role"
        );
    }


    public static RequestPayload<
        object,
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
        object
    > BanComment(int commentId)
    {
        return new(
            method: HttpMethod.Post,
            url: $"/api/comment/{commentId}/ban"
        );
    }

    public static RequestPayload<
        object,
        object,
        object
    > ReportComment(int commentId)
    {
        return new(
            method: HttpMethod.Post,
            url: $"/api/comment/{commentId}/report"
        );
    }
    public static RequestPayload<
        object,
        object,
        object
    > DeleteProfileReport(int commentId)
    {
        return new(
            method: HttpMethod.Delete,
            url: $"/api/profile/nickname/report"
        );
    }
}