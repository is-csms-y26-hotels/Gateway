namespace Gateway.Application.Contracts.Dto.Bookings;

public record GetRoomAvailableDateRangesDto(
    long RoomId,
    DateTime StartDate,
    DateTime EndDate);