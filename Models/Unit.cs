namespace Diosan_Verter.Models;

// Factor = how many base units are in 1 of this unit
// Code is only used by Temperature
public record Unit(string Name, double Factor, string Code = "");
