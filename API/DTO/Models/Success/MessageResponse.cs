using VamaDesktop.API.DTO.Interfaces.Success;

namespace VamaDesktop.API.DTO.Models.Success;

public record MessageResponse : IMessageResponse
{
    public string? Message { get; init; }
}
