using Accommodation.Service.Presentation.Grpc;
using DomainRoomType = Gateway.Application.Contracts.Dto.Rooms.RoomType;

namespace Gateway.Application.Contracts.GrpcClients;

public interface IGrpcRoomClient
{
    public Task<CreateRoomResponse> CreateRoomAsync(long hotelId, long roomNumber, DomainRoomType roomType, decimal price, CancellationToken cancellationToken);

    public Task<UpdateRoomPriceResponse> UpdateRoomPriceAsync(long roomId, decimal price, CancellationToken cancellationToken);

    public Task<SoftDeleteRoomResponse> SoftDeleteRoomAsync(long roomId, CancellationToken cancellationToken);

    public Task<GetRoomsByHotelResponse> GetRoomsByHotelIdAsync(long hotelId, CancellationToken cancellationToken);
}