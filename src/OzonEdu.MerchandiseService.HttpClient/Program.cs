using System;

namespace OzonEdu.MerchandiseService.HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpClient = new System.Net.Http.HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000")
            };
            var client = new MerchandiseHttpClient(httpClient);

            var merchInfo = client.GetMerchInfo(new HttpModels.MerchInfoRequest()).Result;
            Console.WriteLine($"Merch info response status: {merchInfo.Status}");

            var requestMerch = client.RequestMerch(new HttpModels.RequestMerchRequest()).Result;
            Console.WriteLine($"Request merch status: {requestMerch.Status}");
        }
    }
}
