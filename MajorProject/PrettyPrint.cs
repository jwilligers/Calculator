namespace MajorProject
{
    static class PrettyPrint
    {
        public static string Format(string name, Expression expr)
        {
            string value = expr.Value().ToString();
            string unit = expr.GetUnit().ToString();

            return $"{name,-12} {value,-20} {unit}";
        }
    }
}