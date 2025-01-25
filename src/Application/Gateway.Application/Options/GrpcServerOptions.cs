namespace Gateway.Application.Options;

public class GrpcServerOptions
{
    public ServiceOptions? UserService { get; set; }

    public ServiceOptions? AccommodationService { get; set; }

    public ServiceOptions? BookingService { get; set; }
}