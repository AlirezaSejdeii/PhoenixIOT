namespace PhoenixIot.Application.Models;

public record UserInfoDto(Guid Id, string Username, bool IsActive, string? Role, DateTime CreatedAt);