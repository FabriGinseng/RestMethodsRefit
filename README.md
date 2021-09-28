# RestMethodsRefit

The package will be used to simplify the use of http methods (PUT, POST, GET, DELETE) through the REFIT library

# Build
![example workflow](https://github.com/FabriGinseng/RestMethodsRefit/actions/workflows/dotnet.yml/badge.svg)
![Nuget](https://img.shields.io/nuget/v/RefitRestMethodsPackage)

## How to use

import the package:
```c# 
using RefitMethods; 

```
    
Instance the variables:

```c#
//left parameter is how do you want serialize the Object that you send to the server (RequestClass) 
//and in the right there is how do you want to deserialize the Object that the server send to the client (ResponseClass)
ApiRestMethods<RequestClass, ResponseClass> rest = new ApiRestMethods<RequestClass, ResponseClass>();

//if you use basic auth add username and password
ApiRestMethods<RequestClass, ResponseClass> rest = new ApiRestMethods<RequestClass, ResponseClass>(username,password);
```

POST METHOD:
```c#
/// <summary>
/// The method send data in json format to a server to create/update a resource.
/// </summary>
  /// <param name="request"> 
    /// Is the object that the method send to the server
  /// </param>
  /// <param name="URL">
    /// Is the uniform resource locator, it's a Uri class object
      /// <example> 
        /// <code>Uri url = new Uri("http://localhost:3000")</code>
      /// </example>
  /// </param>
  /// <param name="customHeaders">
    /// header's list, it's a dictionary<string,string>
      /// <example>
        /// <code> Dictionary<string, string> header = new Dictionary<string, string>();
        ///         header.Add("key", "value"); </code>
      /// </example>
  /// </param>
        
Response responseFromServer = await rest.PostMethod(request, URL, headers(optional).ConfigureAwait(true);
```


POST WITH QUERY METHOD:
```c#
/// <summary>
  /// The method send data in json format to a server to create/update a resource. In additional the client can send query params
/// </summary>
  /// <param name="queryParams">
    /// dictionary of params <key,value>
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
  
Response responseFromServer = await rest.PostQueryMethod(request, queyParams, url, headers(optional));
```



GET METHOD:
```c#
/// <summary>
  /// The method retrieve data in json format from server.
/// </summary>
  /// <param name="url">
    /// Is the uniform resource locator
  /// </param>
  /// <param name="customHeaders">
    /// header's list 
  /// </param>
  
Response responseFromServer = await rest.GetMethod(url, headers(optional));
```


GET WITH QUERY METHOD:
```c#
/// <summary>
  /// The method retrieve data in json format from server, the client send a query string in the path.
/// </summary>
  /// <param name="queryParams">
    /// the params that will be add in url, dictionary<string,string> query
  /// </param>
  /// <param name="url">
    /// Is the uniform resource locator
  /// </param>
  /// <param name="customHeaders">
    /// header's list 
 /// </param>
        
Response responseFromServer =  await rest.GetQueryMethod(queryParams,url, headers(optional));
```


PUT METHOD:
```c#
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
        
Response responseFromServer = await rest.PutMethod(request,url,headers(optional),queryParams:(optional))
```


DELETE METHOD:
```c#
 /// <summary>
    /// The HTTP DELETE method is used to delete a resource from the server
  /// </summary>
    /// <param name="url">
      /// Is the uniform resource locator
    /// </param>
      /// <param name="customHeaders">
      /// header's list 
    /// </params>
        
Response responseFromServer = await rest.DeleteMethod(url,headers:(optional))
```


The response class is always the same: 
```c#
 /// <summary>
        /// Class response that deserialize a response of each call client/server
 /// </summary>
        Response
        {
            HttpStatusCode statusCode 
            bool isSuccess 
            string message 
            // J is the class you created for the response from the server (ResponseClass in example)
            J payload 
            ApiException error
        }
```


  
