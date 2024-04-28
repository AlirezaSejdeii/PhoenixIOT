namespace PhoenixIot.Models;

public record UpdateDevice(
    Guid Id,
    string Identifier,
    string Switch1Name,
    string Switch2Name,
    string Switch3Name,
    string Switch4Name);