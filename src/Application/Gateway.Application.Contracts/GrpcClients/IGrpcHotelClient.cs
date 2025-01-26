using Accommodation.Service.Presentation.Grpc;

namespace Gateway.Application.Contracts.GrpcClients;

public interface IGrpcHotelClient
{
    public Task<CreateHotelResponse> CreateHotelAsync(string hotelName, string city, int stars, CancellationToken cancellationToken);

    public Task<UpdateHotelStarsResponse> UpdateHotelStarsAsync(string hotelId, int stars, CancellationToken cancellationToken);

    public Task<SoftDeleteHotelResponse> SoftDeleteHotelAsync(string hotelId, CancellationToken cancellationToken);

    public Task<GetHotelsResponse> GetHotelsAsync(string city, int pageSize, long cursor, CancellationToken cancellationToken);
}