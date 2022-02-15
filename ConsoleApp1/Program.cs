using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RefitMethods;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ApiRestMethods<object, object> prova = new ApiRestMethods<object, object>();
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            Dictionary<string, string> header = new Dictionary<string, string>();
            queryParams.Add("servizio", "FSE");
            header.Add("Authorization", "Bearer c57bc208-319a-3a24-889c-4812bb7782ce");
            var responseConnessione = await prova.GetQueryMethod(queryParams, url: new Uri("https://apigw-collaudo.cdp-sanita-coll.soresa.it/fseplus/faq"),header);
        }
    }
}
