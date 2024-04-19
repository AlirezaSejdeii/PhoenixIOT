namespace PhoenixIot.Application.Models;

public record UserDataDto(Guid Id, string Username, List<string> Roles);