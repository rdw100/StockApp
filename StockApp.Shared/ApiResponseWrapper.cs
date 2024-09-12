namespace StockApp.Shared
{
    public class ApiResponseWrapper<T>
    {
        public T Value { get; set; }
        public List<string> Formatters { get; set; }
        public List<string> ContentTypes { get; set; }
        public string DeclaredType { get; set; }
        public int? StatusCode { get; set; }
    }
}