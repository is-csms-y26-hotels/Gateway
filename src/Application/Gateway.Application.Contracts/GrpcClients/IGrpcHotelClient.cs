using System.Collections.ObjectModel;
using HotelDto = Gateway.Application.Contracts.Dto.Hotels.HotelDto;

namespace Gateway.Application.Contracts.GrpcClients;

public interface IGrpcHotelClient
{
    public Task CreateHotelAsync(string hotelName, string city, int stars, CancellationToken cancellationToken);

    public Task UpdateHotelStarsAsync(long hotelId, int stars, CancellationToken cancellationToken);

    public Task SoftDeleteHotelAsync(long hotelId, CancellationToken cancellationToken);

    public Task<Collection<HotelDto>> GetHotelsAsync(string city, int pageSize, long cursor, CancellationToken cancellationToken);
}