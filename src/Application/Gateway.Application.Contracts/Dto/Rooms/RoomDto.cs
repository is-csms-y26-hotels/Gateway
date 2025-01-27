namespace Gateway.Application.Contracts.Dto.Rooms;

public record RoomDto(long RoomId, long HotelId, int RoomNumber, RoomType RoomType, decimal Price);