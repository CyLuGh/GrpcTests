using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcShared;

namespace GrpcTestService.Services
{
    public interface IMicroPoc
    {
        Task<HelloReply> Hello( HelloRequest request , ServerCallContext context );
        Task<SumReply> Sum( SumRequest request , ServerCallContext context );
    }
}
