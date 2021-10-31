using System;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.HttpClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new System.Net.Http.HttpClient()
            {
                BaseAddress = new Uri("http://localhost:5000")
            };
            var client = new MerchandiseHttpClient(httpClient);

            var merchInfo = await client.GetMerchInfo(new HttpModels.MerchInfoRequest());
            Console.WriteLine($"Merch info response status: {merchInfo.Status}");

            var requestMerch = await client.RequestMerch(new HttpModels.RequestMerchRequest());
            Console.WriteLine($"Request merch status: {requestMerch.Status}");
        }
    }
}
