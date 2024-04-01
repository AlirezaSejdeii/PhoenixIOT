namespace PhoenixIot.Application.Models;

public record DeviceDto(List<DeviceItemDto> Items, int TotalCount);