using System.Collections.ObjectModel;
using DomainRoomType = Gateway.Application.Contracts.Dto.Rooms.RoomType;
using RoomDto = Gateway.Application.Contracts.Dto.Rooms.RoomDto;

namespace Gateway.Application.Contracts.GrpcClients;

public interface IGrpcRoomClient
{
    public Task CreateRoomAsync(long hotelId, long roomNumber, DomainRoomType roomType, decimal price, CancellationToken cancellationToken);

    public Task UpdateRoomPriceAsync(long roomId, decimal price, CancellationToken cancellationToken);

    public Task SoftDeleteRoomAsync(long roomId, CancellationToken cancellationToken);

    public Task<Collection<RoomDto>> GetRoomsByHotelIdAsync(long hotelId, DomainRoomType roomType, long cursor, int pageSize, CancellationToken cancellationToken);
}