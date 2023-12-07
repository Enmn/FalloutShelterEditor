using System;

namespace FalloutShelterEditor
{
    internal class StringHelper
    {
        public static string IntegerToString(object value)
        {
            try
            {
                return Math.Truncate(decimal.Parse(value.ToString())).ToString();
            }
            catch
            {
                return "0";
            }
        }

        public static string GetIndent(int indent = 0)
        {
            var output = string.Empty;
            for (var i = 0; i < indent; ++i)
            {
                output += "\t";
            }
            return output;
        }
    }
}
