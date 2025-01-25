using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Gateway.Application.Contracts;

public static class GrpcServiceCollectionExtensions
{
    public static IServiceCollection AddGrpcClients(this IServiceCollection services)
    {
        services.AddGrpcClient<Users.UsersService.Contracts.UsersService.UsersServiceClient>((services, options) =>
        {
            GrpcClientOptions grpcServerOption = services.GetRequiredService<IOptions<GrpcClientOptions>>().Value;
            options.Address = new Uri(grpcServerOption.BaseAddress);
        });

        return services;
    }
}