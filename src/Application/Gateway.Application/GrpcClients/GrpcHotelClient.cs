using Accommodation.Service.Presentation.Grpc;
using Gateway.Application.Contracts.GrpcClients;
using Gateway.Application.Utilities;
using System.Collections.ObjectModel;
using HotelDto = Gateway.Application.Contracts.Dto.Hotels.HotelDto;

namespace Gateway.Application.GrpcClients;

public class GrpcHotelClient : IGrpcHotelClient
{
    private readonly HotelService.HotelServiceClient _hotelServiceClient;

    public GrpcHotelClient(HotelService.HotelServiceClient hotelServiceClient)
    {
        _hotelServiceClient = hotelServiceClient;
    }

    public async Task CreateHotelAsync(string hotelName, string city, int stars, CancellationToken cancellationToken)
    {
        var request = new CreateHotelRequest
        {
            HotelName = hotelName,
            City = city,
            Stars = stars,
        };

        CreateHotelResponse response = await _hotelServiceClient.CreateHotelAsync(request, cancellationToken: cancellationToken);
    }

    public async Task UpdateHotelStarsAsync(long hotelId, int stars, CancellationToken cancellationToken)
    {
        var request = new UpdateHotelStarsRequest
        {
            HotelId = hotelId,
            Stars = stars,
        };

        UpdateHotelStarsResponse response = await _hotelServiceClient.UpdateHotelStarsAsync(request, cancellationToken: cancellationToken);
    }

    public async Task SoftDeleteHotelAsync(long hotelId, CancellationToken cancellationToken)
    {
        var request = new SoftDeleteHotelRequest
        {
            HotelId = hotelId,
        };

        SoftDeleteHotelResponse response = await _hotelServiceClient.SoftDeleteHotelAsync(request, cancellationToken: cancellationToken);
    }

    public async Task<Collection<HotelDto>> GetHotelsAsync(string city, int pageSize, long cursor, CancellationToken cancellationToken)
    {
        var request = new GetHotelsRequest
        {
            City = city,
            Cursor = cursor,
            PageSize = pageSize,
        };

        GetHotelsResponse response = await _hotelServiceClient.GetHotelsAsync(request, cancellationToken: cancellationToken);
        System.Collections.ObjectModel.Collection<Contracts.Dto.Hotels.HotelDto> mappedResult = DtoMapper.MapGrpcHotelToDto(response.HotelList);

        return mappedResult;
    }
}