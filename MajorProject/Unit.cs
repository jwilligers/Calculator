namespace MajorProject
{
    public enum UnitType
    { // there are seven types of tokens
        None, Length, Mass

    }
    class Unit
    {
        UnitType unitType;
        public Unit(UnitType _unitType)
        {
            unitType = _unitType;
        }
        public UnitType GetUnitType()
        { 
            return unitType;
        }
    }
}
