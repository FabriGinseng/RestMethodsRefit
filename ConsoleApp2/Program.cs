using System;
using System.Collections.Generic;
using RefitMethods;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Prova();
            Console.ReadKey();
        }

        public static async void Prova()
        {
            ApiRestMethods<object, Object> prova = new ApiRestMethods<object, object>();
            Dictionary<string, string> test = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            test.Add("testo","dddddddddd");
            headers.Add("struttura","140000");
            var prova2 = await prova.GetQueryMethod(test, new Uri("http://192.168.125.18:3004/api/v2.0/appecupt/aslengi/alpi/prestazionierogabili"),headers);
            Console.Write(prova2);
        }
    }
}
