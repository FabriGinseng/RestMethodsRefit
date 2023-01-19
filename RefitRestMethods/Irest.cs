using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RefitMethods
{
    /// <summary>
    /// The underlying interface contains the signature of the methods to be implemented in the REST class. 
    /// </summary>
    /// <typeparam name="J"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public interface Irest<T, J, in TKey>
    {
        /// <summary>
        /// This method accepts two parameters, payload and headers 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="headers"></param>
        [Post("")]
        Task<ApiResponse<J>> Create([Body] T payload, [HeaderCollection] IDictionary<string, string> headers);


        /// <summary>
        /// This method accepts three parameters, payload, headers and queryparams 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="headers"></param>
        /// <param name="queryParams"></param>
        [Post("")]
        Task<ApiResponse<J>> CreateQuery([Body] T payload, [Query] object queryParams, [HeaderCollection] IDictionary<string, string> headers);

        /// <summary>
        /// This method accepts three parameters, payload that it will be modify in url encoded query, headers. The method return a object (json)
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="headers"></param>
        [Post("")]
        Task<ApiResponse<J>> CreateEncoded([Body(BodySerializationMethod.UrlEncoded)] Dictionary<string,object> payload, [HeaderCollection] IDictionary<string, string> headers);

        /// <summary>
        /// This method accepts one parameter, Headers
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        [Get("")]
        Task<ApiResponse<J>> ReadAll([HeaderCollection] IDictionary<string, string> headers);


        /// <param name="queryParams"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        [Get("")]
        Task<ApiResponse<J>> ReadQuery([Query] object queryParams, [HeaderCollection] IDictionary<string, string> headers);

        /// <summary>
        /// This method accepts two parameter, Headers and queryParams
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="queryParams"></param>
        /// <returns></returns>
        [Get("")]
        Task<ApiResponse<J>> ReadAllQuery([HeaderCollection] IDictionary<string, string> headers, IDictionary<string, string> queryParams);

        /// <summary>
        /// This method accepts two parameters, payload and headers 
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        [Put("")]
        Task<ApiResponse<J>> Update([Body] T payload, [HeaderCollection] IDictionary<string, string> headers);

        /// <summary>
        /// This method accepts one parameter, headers 
        /// </summary>
        /// <param name="headers"></param>
        /// <returns></returns>
        [Delete("")]
        Task<ApiResponse<J>> Delete([HeaderCollection] IDictionary<string, string> headers);
    }
}
