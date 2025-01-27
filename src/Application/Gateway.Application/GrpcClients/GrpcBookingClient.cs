using Bookings.BookingsService.Contracts;
using Gateway.Application.Contracts.Dto.Bookings;
using Gateway.Application.Contracts.GrpcClients;
using Google.Protobuf.WellKnownTypes;

namespace Gateway.Application.GrpcClients;

public class GrpcBookingClient : IGrpcBookingClient
{
    private readonly Bookings.BookingsService.Contracts.BookingService.BookingServiceClient _client;

    public GrpcBookingClient(BookingService.BookingServiceClient client)
    {
        _client = client;
    }

    public async Task<CreateBookingResponse> CreateBookingAsync(CreateBookingDto dto, CancellationToken cancellationToken)
    {
        var request = new CreateBookingRequest
        {
            RoomId = dto.RoomId,
            CheckInDate = Timestamp.FromDateTime(dto.CheckInDate.ToUniversalTime()),
            CheckOutDate = Timestamp.FromDateTime(dto.CheckOutDate.ToUniversalTime()),
        };

        CreateBookingResponse response = await _client.CreateBookingAsync(request, cancellationToken: cancellationToken);
        return response;
    }

    public async Task<PostponeBookingResponse> PostponeBookingAsync(PostponeBookingDto dto, CancellationToken cancellationToken)
    {
        var request = new PostponeBookingRequest
        {
            BookingId = dto.BookingId,
            NewCheckInDate = Timestamp.FromDateTime(dto.NewCheckInDate.ToUniversalTime()),
            NewCheckOutDate = Timestamp.FromDateTime(dto.NewCheckOutDate.ToUniversalTime()),
        };

        PostponeBookingResponse response = await _client.PostponeBookingAsync(request, cancellationToken: cancellationToken);
        return response;
    }

    public async Task<SubmitBookingResponse> SubmitBookingAsync(SubmitBookingDto dto, CancellationToken cancellationToken)
    {
        var request = new SubmitBookingRequest
        {
            BookingId = dto.BookingId,
        };

        SubmitBookingResponse response = await _client.SubmitBookingAsync(request, cancellationToken: cancellationToken);
        return response;
    }

    public async Task<CompleteBookingResponse> CompleteBookingAsync(CompleteBookingDto dto, CancellationToken cancellationToken)
    {
        var request = new CompleteBookingRequest
        {
            BookingId = dto.BookingId,
        };

        CompleteBookingResponse response = await _client.CompleteBookingAsync(request, cancellationToken: cancellationToken);
        return response;
    }

    public async Task<CancelBookingResponse> CancelBookingAsync(CancelBookingDto dto, CancellationToken cancellationToken)
    {
        var request = new CancelBookingRequest
        {
            BookingId = dto.BookingId,
        };

        CancelBookingResponse response = await _client.CancelBookingAsync(request, cancellationToken: cancellationToken);
        return response;
    }

    public async Task<GetRoomAvailableDateRangesResponse> GetRoomAvailableDateRangesAsync(GetRoomAvailableDateRangesDto dto, CancellationToken cancellationToken)
    {
        var request = new GetRoomAvailableDateRangesRequest
        {
            RoomId = dto.RoomId,
            StartDate = Timestamp.FromDateTime(dto.StartDate.ToUniversalTime()),
            EndDate = Timestamp.FromDateTime(dto.EndDate.ToUniversalTime()),
        };

        GetRoomAvailableDateRangesResponse response = await _client.GetRoomAvailableDateRangesAsync(request, cancellationToken: cancellationToken);
        return response;
    }
}