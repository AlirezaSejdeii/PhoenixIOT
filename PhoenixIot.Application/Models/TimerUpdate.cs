namespace PhoenixIot.Application.Models;

public record TimerUpdate(
    string Identifier,
    int StartHourAtRelay1,
    int StartMinAtRelay1,
    int EndHourAtRelay1,
    int EndMinAtRelay1,
    int StartHourAtRelay2,
    int StartMinAtRelay2,
    int EndHourAtRelay2,
    int EndMinAtRelay2,
    int StartHourAtRelay3,
    int StartMinAtRelay3,
    int EndHourAtRelay3,
    int EndMinAtRelay3,
    int StartHourAtRelay4,
    int StartMinAtRelay4,
    int EndHourAtRelay4,
    int EndMinAtRelay4
);