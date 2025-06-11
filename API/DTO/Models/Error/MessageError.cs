using VamaDesktop.API.DTO.Interfaces.Error;

namespace VamaDesktop.API.DTO.Models.Error;

public record MessageError : IMessageError
{
    public string? Message { get; init; }
}
