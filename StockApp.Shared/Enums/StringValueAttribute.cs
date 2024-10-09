namespace StockApp.Shared.Enums
{
    /// <summary>
    /// Allows string attributes to be applied
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class StringValueAttribute : Attribute
    {
        public string StringValue { get; }

        public StringValueAttribute(string value)
        {
            StringValue = value;
        }
    }
}
