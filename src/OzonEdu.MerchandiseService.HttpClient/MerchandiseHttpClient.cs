using OzonEdu.MerchandiseService.HttpModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NetHttpClient = System.Net.Http.HttpClient;

namespace OzonEdu.MerchandiseService.HttpClient
{
    public interface IMerchandiseHttpClient
    {
        Task<RequestMerchResponse> RequestMerch(RequestMerchRequest request, CancellationToken token);
        Task<MerchInfoResponse> GetMerchInfo(MerchInfoRequest request, CancellationToken token);
    }

    public class MerchandiseHttpClient : IMerchandiseHttpClient
    {
        private readonly NetHttpClient _httpClient;

        public MerchandiseHttpClient(NetHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MerchInfoResponse> GetMerchInfo(MerchInfoRequest request, 
            CancellationToken token = default)
        {
            using var response = await _httpClient.GetAsync("api/v1/merch/info", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchInfoResponse>(body, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<RequestMerchResponse> RequestMerch(RequestMerchRequest request, 
            CancellationToken token = default)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                "application/json");
            using var response = await _httpClient.PostAsync("api/v1/merch/request", content, token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<RequestMerchResponse>(body, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
