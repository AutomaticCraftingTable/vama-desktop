namespace VamaDesktop.API.DTO.Errors;

public record CommonErrorRecord<T>
{
    public string Message { get; init; } = string.Empty;
    public T? Errors { get; init; }
}