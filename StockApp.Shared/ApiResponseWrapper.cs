namespace StockApp.Shared
{
    /// <summary>
    /// Encapsulates responses from an API call using a standard structure.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponseWrapper<T>
    {
        /// <summary>
        /// The generic type data returned by the API.
        /// </summary>
        public T Value { get; set; }
        /// <summary>
        /// The list of formatters used to serialize or deserialize the response data
        /// </summary>
        public List<string> Formatters { get; set; }
        /// <summary>
        /// The list of content types (e.g., application/json, text/xml) of the formatted response.
        /// </summary>
        public List<string> ContentTypes { get; set; }
        /// <summary>
        /// The declared type of the response data.
        /// </summary>
        public string DeclaredType { get; set; }
        /// <summary>
        /// The HTTP status code of the response,
        /// </summary>
        public int? StatusCode { get; set; }
    }
}