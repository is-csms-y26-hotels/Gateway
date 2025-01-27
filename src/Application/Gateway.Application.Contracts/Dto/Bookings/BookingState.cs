namespace Gateway.Application.Contracts.Dto.Bookings;

public enum BookingState
{
    BookingStateUnspecified = 0,
    BookingStateCreated = 1,
    BookingStateSubmitted = 3,
    BookingStateCancelled = 4,
    BookingStateCompleted = 5,
}