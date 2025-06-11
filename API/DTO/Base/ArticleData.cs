using System.Text.Json.Serialization;

namespace VamaDesktop.API.DTO.Base;

public record ArticleData
{
    public int Id { get; init; }
    public string Thumbnail { get; init; }
    public string Tags { get; init; }
    public string Content { get; init; }
    public string Title { get; init; }
    public ProfileData Profile { get; init; }
    public int Subscribers { get; init; }
    
    [property: JsonPropertyName("account_id")]
    public int AccountId { get; init; }
    [property: JsonPropertyName("banned_at")]
    public string BannedId { get; init; }
    [property: JsonPropertyName("created_at")]
    public string CreatedAt { get; init; }
    [property: JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; }
}

// "articles": [
// {
//     "id": 15,
//     "author": "lullrich",
//     "title": "Consequatur molestiae aperiam deserunt et consequatur atque.",
//     "content": "Id explicabo consectetur debitis velit. Aliquam sapiente velit beatae. Ut itaque exercitationem laudantium repudiandae blanditiis natus. Aut occaecati est exercitationem qui incidunt nihil officia. Facere debitis ipsam recusandae quos. Dolorum debitis saepe veniam est voluptatem suscipit. Et consequatur magnam officiis.",
//     "tags": "delectus,sint,sit",
//     "thumbnail": "https://via.placeholder.com/640x480.png/006699?text=adipisci",
//     "banned_at": null,
//     "created_at": "2025-06-10T03:45:50Z",
//     "updated_at": "2025-06-10T03:45:50Z",
//     "profile": {
//         "nickname": "lullrich",
//         "user_id": 4,
//         "description": "Omnis provident asperiores molestiae adipisci vero.",
//         "logo": "https://via.placeholder.com/100x100.png/0022ee?text=logo+est",
//         "created_at": "2025-06-10T03:45:44Z",
//         "updated_at": "2025-06-10T03:45:44Z",
//         "followers_count": 0
//     },
//     "likes": []
