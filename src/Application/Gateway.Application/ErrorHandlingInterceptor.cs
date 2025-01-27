using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;

namespace Gateway.Application;

public class ErrorHandlingInterceptor : Interceptor
{
    private readonly ILogger<ErrorHandlingInterceptor> _logger;

    public ErrorHandlingInterceptor(ILogger<ErrorHandlingInterceptor> logger)
    {
        _logger = logger;
    }

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        try
        {
            return await continuation(request, context);
        }
        catch (RpcException ex)
        {
            _logger.LogError(ex, "gRPC exception occurred.");

            throw new RpcException(new Status(StatusCode.Internal, ex.Message), "An error occurred during the request.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception.");

            throw new RpcException(new Status(StatusCode.Internal, "Internal server error"), "An internal error occurred.");
        }
    }
}
