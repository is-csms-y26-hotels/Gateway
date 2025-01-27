using Accommodation.Service.Presentation.Grpc;
using Gateway.Application.Contracts.GrpcClients;
using Gateway.Application.Utilities;
using System.Collections.ObjectModel;
using RoomDto = Gateway.Application.Contracts.Dto.Rooms.RoomDto;
using RoomType = Gateway.Application.Contracts.Dto.Rooms.RoomType;

namespace Gateway.Application.GrpcClients;

public class GrpcRoomClient : IGrpcRoomClient
{
    private readonly RoomService.RoomServiceClient _roomServiceClient;

    public GrpcRoomClient(RoomService.RoomServiceClient roomServiceClient)
    {
        _roomServiceClient = roomServiceClient;
    }

    public async Task CreateRoomAsync(long hotelId, long roomNumber, RoomType roomType, decimal price, CancellationToken cancellationToken)
    {
        Accommodation.Service.Presentation.Grpc.RoomType mappedEnum = RoomTypeEnumMapper.MapRoomTypeToGrpcEnum(roomType);

        var request = new CreateRoomRequest
        {
            HotelId = hotelId,
            Price = MoneyMapper.MapMoneyType(price),
            RoomNumber = roomNumber,
            RoomType = mappedEnum,
        };

        CreateRoomResponse response = await _roomServiceClient.CreateRoomAsync(request, cancellationToken: cancellationToken);
    }

    public async Task UpdateRoomPriceAsync(long roomId, decimal price, CancellationToken cancellationToken)
    {
        var request = new UpdateRoomPriceRequest
        {
            RoomId = roomId,
            Price = MoneyMapper.MapMoneyType(price),
        };

        UpdateRoomPriceResponse response = await _roomServiceClient.UpdateRoomPriceAsync(request, cancellationToken: cancellationToken);
    }

    public async Task SoftDeleteRoomAsync(long roomId, CancellationToken cancellationToken)
    {
        var request = new SoftDeleteRoomRequest
        {
            RoomId = roomId,
        };

        SoftDeleteRoomResponse response = await _roomServiceClient.SoftDeleteRoomAsync(request, cancellationToken: cancellationToken);
    }

    public async Task<Collection<RoomDto>> GetRoomsByHotelIdAsync(long hotelId, RoomType roomType, long cursor, int pageSize, CancellationToken cancellationToken)
    {
        Accommodation.Service.Presentation.Grpc.RoomType mappedEnum = RoomTypeEnumMapper.MapRoomTypeToGrpcEnum(roomType);
        var request = new GetRoomsByHotelRequest
        {
            HotelId = hotelId,
            RoomType = mappedEnum,
            Cursor = cursor,
            PageSize = pageSize,
        };

        GetRoomsByHotelResponse response = await _roomServiceClient.GetRoomsByHotelAsync(request, cancellationToken: cancellationToken);
        Collection<RoomDto> mappedResult = DtoMapper.MapGrpcRoomToDto(response.RoomsList);

        return mappedResult;
    }
}