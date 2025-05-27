using System.Text.Json.Serialization;

namespace VamaDesktop.API.DTO.Exceptions;

public class ErrorMessageResponse
{
    [property: JsonPropertyName("message")]
    public string Message { get; set; }
}
