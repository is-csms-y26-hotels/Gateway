using Gateway.Application.Contracts.GrpcClients;
using Gateway.Application.GrpcClients;
using Gateway.Application.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Gateway.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddGrpcClient<Users.UsersService.Contracts.UsersService.UsersServiceClient>((services, options) =>
        {
            GrpcServerOptions grpcServerOptions = services.GetRequiredService<IOptions<GrpcServerOptions>>().Value;
            if (grpcServerOptions.UserService is null)
                throw new NullReferenceException("Options object for GrpcUserClient is null");
            options.Address = new Uri(grpcServerOptions.UserService.BaseAddress);
        });

        collection.AddScoped<IGrpcUserClient, GrpcUserClient>();

        // TODO. Add other clients and their options
        return collection;
    }
}