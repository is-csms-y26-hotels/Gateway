using Gateway.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Gateway.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddGrpcClient<Users.UsersService.Contracts.UsersService.UsersServiceClient>((services, options) =>
        {
        GrpcClientOptions grpcServerOption = services.GetRequiredService<IOptions<GrpcClientOptions>>().Value;
        options.Address = new Uri(grpcServerOption.BaseAddress);
        });

        collection.AddScoped<IGrpcClient, GrpcClient>();

        return collection;
    }
}