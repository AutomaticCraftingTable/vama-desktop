using VamaDesktop.API.DTO.Interfaces.Error;

namespace VamaDesktop.API.DTO.Models.Error;

public record CommonErrorRecord<T> : IMessageError
{
    public string? Message { get; init; }
    public T? Errors { get; init; }
}