using Bookings.BookingsService.Contracts;
using Gateway.Application.Contracts.Dto.Bookings;

namespace Gateway.Application.Contracts.GrpcClients;

public interface IGrpcBookingClient
{
    public Task<CreateBookingResponse> CreateBookingAsync(
        CreateBookingDto dto,
        CancellationToken cancellationToken);

    public Task<PostponeBookingResponse> PostponeBookingAsync(
        PostponeBookingDto dto,
        CancellationToken cancellationToken);

    public Task<SubmitBookingResponse> SubmitBookingAsync(
        SubmitBookingDto dto,
        CancellationToken cancellationToken);

    public Task<CompleteBookingResponse> CompleteBookingAsync(
        CompleteBookingDto dto,
        CancellationToken cancellationToken);

    public Task<CancelBookingResponse> CancelBookingAsync(
        CancelBookingDto dto,
        CancellationToken cancellationToken);

    public Task<GetRoomAvailableDateRangesResponse> GetRoomAvailableDateRangesAsync(
        GetRoomAvailableDateRangesDto dto,
        CancellationToken cancellationToken);
}