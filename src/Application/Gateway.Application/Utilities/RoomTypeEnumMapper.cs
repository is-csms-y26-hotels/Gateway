using Accommodation.Service.Presentation.Grpc;
using InvalidOperationException = System.InvalidOperationException;

namespace Gateway.Application.Utilities;

public static class RoomTypeEnumMapper
{
    public static RoomType MapRoomTypeToGrpcEnum(Contracts.Dto.Rooms.RoomType roomType)
    {
        return roomType switch
        {
            Contracts.Dto.Rooms.RoomType.Standard => RoomType.Standard,
            Contracts.Dto.Rooms.RoomType.Twin => RoomType.Twin,
            Contracts.Dto.Rooms.RoomType.Studio => RoomType.Studio,
            Contracts.Dto.Rooms.RoomType.JuniorSuite => RoomType.JuniorSuite,
            Contracts.Dto.Rooms.RoomType.Deluxe => RoomType.Deluxe,
            _ => throw new InvalidOperationException(),
        };
    }

    public static Contracts.Dto.Rooms.RoomType MapRoomTypeFromGrpcEnum(RoomType roomType)
    {
        return roomType switch
        {
            RoomType.Unspecified => throw new InvalidOperationException(),
            RoomType.Standard => Contracts.Dto.Rooms.RoomType.Standard,
            RoomType.Twin => Contracts.Dto.Rooms.RoomType.Twin,
            RoomType.Studio => Contracts.Dto.Rooms.RoomType.Studio,
            RoomType.JuniorSuite => Contracts.Dto.Rooms.RoomType.JuniorSuite,
            RoomType.Deluxe => Contracts.Dto.Rooms.RoomType.Deluxe,
            _ => throw new InvalidOperationException(),
        };
    }
}