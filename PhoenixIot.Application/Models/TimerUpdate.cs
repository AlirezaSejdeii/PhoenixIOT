namespace PhoenixIot.Application.Models;

public record TimerUpdate(string Identifier, int StartHourAt, int StartMinAt, int EndHourAt, int EndMinAt);