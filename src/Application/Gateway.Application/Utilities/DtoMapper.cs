using Gateway.Application.Contracts.Dto.Hotels;
using Gateway.Application.Contracts.Dto.Rooms;
using Google.Protobuf.Collections;
using System.Collections.ObjectModel;
using GrpcHotelDto = Accommodation.Service.Presentation.Grpc.HotelDto;
using GrpcRoomDto = Accommodation.Service.Presentation.Grpc.RoomDto;

namespace Gateway.Application.Utilities;

public static class DtoMapper
{
    public static Collection<RoomDto> MapGrpcRoomToDto(RepeatedField<Accommodation.Service.Presentation.Grpc.RoomDto> rooms)
    {
        var result = new Collection<RoomDto>();

        foreach (GrpcRoomDto room in rooms)
        {
            RoomType mappedEnum = RoomTypeEnumMapper.MapRoomTypeFromGrpcEnum(room.RoomType);
            result.Add(new RoomDto(
                RoomId: room.RoomId,
                HotelId: room.HotelId,
                RoomNumber: room.RoomNumber,
                RoomType: mappedEnum,
                Price: room.Price.DecimalValue));
        }

        return result;
    }

    public static Collection<HotelDto> MapGrpcHotelToDto(RepeatedField<Accommodation.Service.Presentation.Grpc.HotelDto> hotels)
    {
        var result = new Collection<HotelDto>();

        foreach (GrpcHotelDto hotel in hotels)
        {
            result.Add(new HotelDto(
                HotelId: hotel.HotelId,
                Name: hotel.Name,
                Stars: hotel.Stars,
                City: hotel.City));
        }

        return result;
    }
}