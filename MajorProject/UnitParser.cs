using System;
using System.Collections.Generic;

namespace MajorProject
{
    static class UnitParser
    {
        private static readonly Dictionary<string, Unit> Units =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "m",   new Unit(UnitType.Meter) },
                { "kg",  new Unit(UnitType.Kilogram) },
                { "s",   new Unit(UnitType.Second) },
                { "A",   new Unit(UnitType.Ampere) },
                { "K",   new Unit(UnitType.Kelvin) },
                { "mol", new Unit(UnitType.Mole) },
                { "cd",  new Unit(UnitType.Candela) },
                { "rad", new Unit(UnitType.Radian) }
            };

        public static bool TryParse(string name, out Unit unit)
        {
            return Units.TryGetValue(name, out unit);
        }
    }
    static class UnitConverter
    {
        public static readonly Dictionary<string, double> Factors =
            new(StringComparer.OrdinalIgnoreCase)
            {
            { "m", 1 },
            { "cm", 0.01 },
            { "mm", 0.001 },
            { "km", 1000 },

            { "s", 1 },
            { "min", 60 },
            { "hr", 3600 },

            { "g", 0.001 },
            { "kg", 1 },

            { "N", 1 }, // optional derived units
            };
    }
}
