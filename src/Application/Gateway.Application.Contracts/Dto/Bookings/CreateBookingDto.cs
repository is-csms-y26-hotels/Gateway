namespace Gateway.Application.Contracts.Dto.Bookings;

public record CreateBookingDto(
    string UserEmail,
    long RoomId,
    DateTime CheckInDate,
    DateTime CheckOutDate);