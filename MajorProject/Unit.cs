using System.Collections.Generic;

namespace MajorProject
{
    public enum UnitType
    {
        None,
        Meter,
        Kilogram,
        Second,
        Ampere,
        Kelvin,
        Mole,
        Joule,
        Candela,
        Radian
    }


    public class Unit
    {
        public Dictionary<UnitType, int> Dimensions { get; }

        public Unit()
        {
            Dimensions = new Dictionary<UnitType, int>();
        }

        public Unit(UnitType type)
        {
            Dimensions = new Dictionary<UnitType, int>();
            if (type != UnitType.None)
                Dimensions[type] = 1;
        }

        public static Unit operator *(Unit a, Unit b)
        {
            var result = new Unit();
            foreach (var kv in a.Dimensions)
                result.Dimensions[kv.Key] = kv.Value;

            foreach (var kv in b.Dimensions)
            {
                if (!result.Dimensions.ContainsKey(kv.Key))
                    result.Dimensions[kv.Key] = 0;

                result.Dimensions[kv.Key] += kv.Value;
            }

            return result;
        }

        public static Unit operator /(Unit a, Unit b)
        {
            var result = new Unit();
            foreach (var kv in a.Dimensions)
                result.Dimensions[kv.Key] = kv.Value;

            foreach (var kv in b.Dimensions)
            {
                if (!result.Dimensions.ContainsKey(kv.Key))
                    result.Dimensions[kv.Key] = 0;

                result.Dimensions[kv.Key] -= kv.Value;
            }

            return result;
        }

        public Unit Pow(int exponent)
        {
            var result = new Unit();
            foreach (var kv in Dimensions)
                result.Dimensions[kv.Key] = kv.Value * exponent;
            return result;
        }

        public bool IsDimensionless()
        {
            return Dimensions.Count == 0;
        }
    }

}
