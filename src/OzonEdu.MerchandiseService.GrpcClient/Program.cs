using Grpc.Net.Client;
using System;

namespace OzonEdu.MerchandiseService.GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Grpc.MerchandiseServiceGrpc
                .MerchandiseServiceGrpcClient(channel);

            var merchInfo = client.GetMerchGivingInfo(new Grpc.GetMerchGivingInfoRequest());
            Console.WriteLine($"Merch info response status: {merchInfo.Status}");

            var requestMerch = client.RequestMerch(new Grpc.RequestMerchRequest());
            Console.WriteLine($"Request merch status: {requestMerch.Status}");
        }
    }
}
