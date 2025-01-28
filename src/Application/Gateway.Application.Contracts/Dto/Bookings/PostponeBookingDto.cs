namespace Gateway.Application.Contracts.Dto.Bookings;

public record PostponeBookingDto(
    long BookingId,
    DateTime NewCheckInDate,
    DateTime NewCheckOutDate);