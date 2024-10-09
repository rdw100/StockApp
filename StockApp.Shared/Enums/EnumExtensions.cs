using System.Reflection;

namespace StockApp.Shared.Enums
{
    /// <summary>
    /// Extension method to get the string value
    /// </summary>
    public static class EnumExtensions
    {
        public static string? GetStringValue(this Enum value)
        {
            FieldInfo? field = value.GetType().GetField(value.ToString());
            if (field == null) return null;

            StringValueAttribute? attribute = field.GetCustomAttributes(typeof(StringValueAttribute), false)
                                                  .FirstOrDefault() as StringValueAttribute;

            return attribute?.StringValue;
        }
    }
}
