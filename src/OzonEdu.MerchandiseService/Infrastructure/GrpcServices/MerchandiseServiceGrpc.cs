using Grpc.Core;
using OzonEdu.MerchandiseService.Grpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.GrpcServices
{
    public class MerchandiseServiceGrpc : OzonEdu.MerchandiseService.Grpc.MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        public override async Task<RequestMerchResponse> RequestMerch(RequestMerchRequest request, ServerCallContext context)
        {
            return new RequestMerchResponse() { Status = "Merch requested" };
        }

        public override async Task<GetMerchGivingInfoResponse> GetMerchGivingInfo(GetMerchGivingInfoRequest request, ServerCallContext context)
        {
            return new GetMerchGivingInfoResponse() { Status = "In progress" };
        }
    }
}
