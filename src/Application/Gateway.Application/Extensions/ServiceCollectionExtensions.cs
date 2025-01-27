using Accommodation.Service.Presentation.Grpc;
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

        collection.AddGrpcClient<HotelService.HotelServiceClient>((services, options) =>
        {
            GrpcServerOptions grpcServerOptions = services.GetRequiredService<IOptions<GrpcServerOptions>>().Value;
            if (grpcServerOptions.AccommodationService is null)
                throw new NullReferenceException("Options object for GrpcHotelClient is null");
            options.Address = new Uri(grpcServerOptions.AccommodationService.BaseAddress);
        });

        collection.AddGrpcClient<RoomService.RoomServiceClient>((services, options) =>
        {
            GrpcServerOptions grpcServerOptions = services.GetRequiredService<IOptions<GrpcServerOptions>>().Value;
            if (grpcServerOptions.AccommodationService is null)
                throw new NullReferenceException("Options object for GrpcRoomClient is null");
            options.Address = new Uri(grpcServerOptions.AccommodationService.BaseAddress);
        });

        collection.AddGrpcClient<Bookings.BookingsService.Contracts.BookingService.BookingServiceClient>((services, options) =>
        {
            GrpcServerOptions grpcServerOptions = services.GetRequiredService<IOptions<GrpcServerOptions>>().Value;
            if (grpcServerOptions.BookingService is null)
                throw new NullReferenceException("Options object for GrpcBookingClient is null");
            options.Address = new Uri(grpcServerOptions.BookingService.BaseAddress);
        });

        collection.AddScoped<IGrpcUserClient, GrpcUserClient>();
        collection.AddScoped<IGrpcHotelClient, GrpcHotelClient>();
        collection.AddScoped<IGrpcRoomClient, GrpcRoomClient>();
        collection.AddScoped<IGrpcBookingClient, GrpcBookingClient>();
        return collection;
    }
}