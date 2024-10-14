namespace StockApp.Client.Models
{
    /// <summary>
    /// Encapsulates responses from an API call using a standard structure.
    /// </summary>
    /// <typeparam name="T">The generic type for response data</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// The data structure type from a successful request
        /// </summary>
        public T? Data { get; set; }
        /// <summary>
        /// The error message received for response failure
        /// </summary>
        public string? ErrorMessage { get; set; }
        /// <summary>
        /// The HTTP status code of the response
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// True if the request was successful; otherwise, false.
        /// </summary>
        public bool IsSuccess { get; set; } 

        /// <summary>
        /// The default constructor
        /// </summary>
        //public ApiResponse() { }

        // Constructor for successful response
        /// <summary>
        /// Defines successful response setting response type and status
        /// </summary>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        public ApiResponse(T data, int statusCode)
        {
            Data = data;
            StatusCode = statusCode;
            IsSuccess = true;
        }

        /// <summary>
        /// Defines unsuccessful response setting error and status
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="statusCode"></param>
        public ApiResponse(string errorMessage, int statusCode)
        {
            ErrorMessage = errorMessage;
            StatusCode = statusCode;
            IsSuccess = false;
        }
    }
}