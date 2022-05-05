using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace RefitMethods
{

    /// <summary>
    /// The class implements multiple methods that can be used for REST API (POST, GET, DELETE,PUT)
    /// </summary>
    /// <typeparam name="J">
    /// J is the return class
    /// </typeparam>
    /// <typeparam name="T">
    /// T is the request class
    /// </typeparam>
    public class ApiRestMethods<T, J>
    {
        private HttpClientHandler httpClientHandler { get; set; } = new HttpClientHandler();
        private RefitSettings settings = new RefitSettings(new NewtonsoftJsonContentSerializer());
        private string authorizationHeaders;
        public ApiRestMethods()
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }

        public ApiRestMethods(string usernameBasicAuth, string passwordBasicAuth)
        {
           Task.Run(async () =>
           {
                if (!string.IsNullOrWhiteSpace(usernameBasicAuth) && !string.IsNullOrWhiteSpace(passwordBasicAuth))
                   authorizationHeaders = "Basic " + await returnBasicToken(usernameBasicAuth, passwordBasicAuth);
           });
        }

        /// <summary>
        /// The method send data in json format to a server to create/update a resource.
        /// </summary>
        /// <param name="request"> 
        /// Is the object that the method send to the server
        /// </param>
        /// <param name="url">
        /// Is the uniform resource locator
        /// </param>
        /// <param name="customHeaders">
        /// header's list 
        /// </param>
        public async Task<Response> PostMethod(T request, Uri url, Dictionary<string, string> customHeaders = null)
        {
            try
            {
                if (url == null)
                    return new Response("Insert URL please");

                var api = RestService.For<Irest<T, J, string>>(new HttpClient(handler: httpClientHandler)
                {
                    BaseAddress = url,

                }, settings);

                if (!string.IsNullOrWhiteSpace(authorizationHeaders))
                    if (customHeaders != null)
                        customHeaders.Add("Authorization", authorizationHeaders);

                var i = await api.Create(request, customHeaders).ConfigureAwait(true);
                return new Response(i);

            }
            catch (ApiException apiException)
            {
                return new Response(apiException);
            }
            catch (Exception errorGeneric)
            {
                return new Response(errorGeneric);
            }
        }


        /// <summary>
        /// The method send data in json format to a server to create/update a resource.
        /// </summary>
        /// <param name="request"> 
        /// Is the object that the method send to the server
        /// </param>
        /// <param name="url">
        /// Is the uniform resource locator
        /// </param>
        /// <param name="customHeaders">
        /// header's list 
        /// </param>
        public async Task<Response> PostUrlEncodedMethod(Dictionary<string,object> request, Uri url, Dictionary<string, string> customHeaders = null)
        {
            try
            {
                if (url == null)
                    return new Response("Insert URL please");

                var api = RestService.For<Irest<T, J, string>>(new HttpClient(handler: httpClientHandler)
                {
                    BaseAddress = url,

                }, settings);

                if (!string.IsNullOrWhiteSpace(authorizationHeaders))
                    if (customHeaders != null)
                        customHeaders.Add("Authorization", authorizationHeaders);

                var i = await api.CreateEncoded(request, customHeaders).ConfigureAwait(true);
                return new Response(i);

            }
            catch (ApiException apiException)
            {
                return new Response(apiException);
            }
            catch (Exception errorGeneric)
            {
                return new Response(errorGeneric);
            }
        }



        /// <summary>
        /// The method retrieve data in json format from server.
        /// </summary>
        /// <param name="url">
        /// Is the uniform resource locator
        /// </param>
        /// <param name="customHeaders">
        /// header's list 
        /// </param>
        public async Task<Response> GetMethod(Uri url, Dictionary<string, string> customHeaders = null)
        {
            try
            {
                if (url == null)
                    return new Response("Insert URL please");

                var api = RestService.For<Irest<T, J, string>>(new HttpClient(handler: httpClientHandler)
                {
                    BaseAddress = url,

                }, settings);

                if (!string.IsNullOrWhiteSpace(authorizationHeaders))
                    if (customHeaders != null)
                        customHeaders.Add("Authorization", authorizationHeaders);

                var i = await api.ReadAll(customHeaders).ConfigureAwait(true);
                return new Response(i);

            }
            catch (ApiException apiException)
            {
                return new Response(apiException);
            }
            catch (Exception errorGeneric)
            {
                return new Response(errorGeneric);
            }
        }

        /// <summary>
        /// The method retrieve data in json format from server, the client send a query string in the path.
        /// </summary>
        /// <param name="queryParams">
        /// the params that will be add in url
        /// </param>
        /// <param name="url">
        /// Is the uniform resource locator
        /// </param>
        /// <param name="customHeaders">
        /// header's list 
        /// </param>
        public async Task<Response> GetQueryMethod(Dictionary<string, string> queryParams, Uri url, Dictionary<string, string> customHeaders = null)
        {
            try
            {
                if (url == null)
                    return new Response("Insert URL please");
                

                var api = RestService.For<Irest<T, J, string>>(new HttpClient(handler: httpClientHandler)
                {
                    BaseAddress = url
                }, settings);

                if (!string.IsNullOrWhiteSpace(authorizationHeaders))
                    if (customHeaders != null)
                        customHeaders.Add("Authorization", authorizationHeaders);

                var i = await api.ReadAllQuery(customHeaders, queryParams).ConfigureAwait(true);
                return new Response(i);

            }
            catch (ApiException apiException)
            {
                return new Response(apiException);
            }
            catch (Exception errorGeneric)
            {
                return new Response(errorGeneric);
            }
        }

        /// <summary>
        /// The method send data in json format to a server to create/update a resource. In additional the client can send query params
        /// </summary>
        /// <param name="queryParams">
        /// Object query params refit Alias
        /// </param>
        /// <param name="request"> 
        /// Is the object that the method send to the server
        /// </param>
        /// <param name="url">
        /// Is the uniform resource locator
        /// </param>
        /// <param name="customHeaders">
        /// header's list 
        /// </param>
        public async Task<Response> PostQueryMethod(T request, Object queryParams, Uri url, Dictionary<string, string> customHeaders = null)
        {
            try
            {
                if (url == null)
                    return new Response("Insert URL please");
                var api = RestService.For<Irest<T, J, string>>(new HttpClient(handler: httpClientHandler)
                {
                    BaseAddress = url,
                }, settings);

                if (!string.IsNullOrWhiteSpace(authorizationHeaders))
                    customHeaders.Add("Authorization", authorizationHeaders);

                var i = await api.CreateQuery(request, queryParams, customHeaders).ConfigureAwait(true);
                return new Response(i);

            }
            catch (ApiException apiException)
            {
                return new Response(apiException);
            }
            catch (Exception errorGeneric)
            {
                return new Response(errorGeneric);
            }
        }

        /// <summary>
        /// PUT method is used to update resource available on the server. 
        /// </summary>
        /// <param name="queryParams">
        /// list of params <key,value>, optional
        /// </param>
        /// <param name="request"> 
        /// Is the object that the method send to the server
        /// </param>
        /// <param name="url">
        /// Is the uniform resource locator
        /// </param>
        /// <param name="customHeaders">
        /// header's list 
        /// </param>
        public async Task<Response> PutMethod(T request, Uri url, Dictionary<string, string> customHeaders = null, Dictionary<string, string> queryParams = null)
        {
            try
            {
                if (url == null)
                    return new Response("Insert URL please");

                if (!string.IsNullOrWhiteSpace(authorizationHeaders))
                    if (customHeaders != null)
                        customHeaders.Add("Authorization", authorizationHeaders);

                if (queryParams != null && queryParams.Count > 0)
                {
                    var uriBuilder = new UriBuilder(url);
                    var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                    foreach (KeyValuePair<string, string> querypar in queryParams)
                    {
                        query[querypar.Key] = querypar.Value;
                    }
                    uriBuilder.Query = query.ToString();
                    var longurl = uriBuilder.ToString();
                    var api = RestService.For<Irest<T, J, string>>(new HttpClient(handler: httpClientHandler)
                    {
                        BaseAddress = new Uri(longurl),

                    }, settings);
                    var i = await api.Update(request, customHeaders).ConfigureAwait(true);
                    return new Response(i);
                }
                else
                {
                    var api = RestService.For<Irest<T, J, string>>(new HttpClient(handler: httpClientHandler)
                    {
                        BaseAddress = url,

                    }, settings);

                    var i = await api.Create(request, customHeaders).ConfigureAwait(true);
                    return new Response(i);

                }
            }
            catch (ApiException apiException)
            {
                return new Response(apiException);
            }
            catch (Exception errorGeneric)
            {
                return new Response(errorGeneric);
            }
        }


        /// <summary>
        /// The HTTP DELETE method is used to delete a resource from the server
        /// </summary>
        /// <param name="url">
        /// Is the uniform resource locator
        /// </param>
        /// <param name="customHeaders">
        /// header's list 
        /// </param>
        public async Task<Response> DeleteMethod(Uri url, Dictionary<string, string> customHeaders = null)
        {
            try
            {
                if (url == null)
                    return new Response("Insert URL please");

                if (!string.IsNullOrWhiteSpace(authorizationHeaders))
                    if (customHeaders != null)
                        customHeaders.Add("Authorization", authorizationHeaders);

                var api = RestService.For<Irest<T, J, string>>(new HttpClient(handler: httpClientHandler)
                {
                    BaseAddress = url,

                }, settings);

                var i = await api.Delete(customHeaders).ConfigureAwait(true);
                return new Response(i);

            }
            catch (ApiException apiException)
            {
                return new Response(apiException);
            }
            catch (Exception errorGeneric)
            {
                return new Response(errorGeneric);
            }
        }

        private async Task<string> returnBasicToken(string username, string password)
        {
            var byteText = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
            return Convert.ToBase64String(byteText);
        }

        /// <summary>
        /// Class response that deserialize a response of each call client/server
        /// </summary>
        public class Response
        {
            public HttpStatusCode statusCode { get; set; }
            public bool isSuccess { get; set; }
            public string message { get; set; }
            public J payload { get; set; }
            public ApiException error { get; set; }

            internal Response(ApiResponse<J> obj)
            {
                statusCode = obj.StatusCode;
                isSuccess = obj.IsSuccessStatusCode;
                message = obj.ReasonPhrase;
                payload = obj.Content;
            }

            internal Response(string obj)
            {
                statusCode = HttpStatusCode.NotAcceptable;
                isSuccess = false;
                message = obj;
            }

            internal Response(Exception obj)
            {
                isSuccess = false;
                message = obj.Message;
            }
            internal Response(ApiException obj)
            {
                statusCode = obj.StatusCode;
                isSuccess = false;
                message = obj.ReasonPhrase;
                error = obj;
            }
        }
    }
}
