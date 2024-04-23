namespace PhoenixIot.Application.Models;

public record UserInfoDto(Guid Id, string Username, bool IsActive, DateTime CreatedAt);