using Bookings.BookingsService.Contracts;
using Gateway.Application.Contracts.Dto.Bookings;
using Gateway.Application.Contracts.GrpcClients;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Presentation.Http.Controllers;

[ApiController]
[Route("api/bookings")]
public class BookingController : ControllerBase
{
    private readonly IGrpcBookingClient _client;

    public BookingController(IGrpcBookingClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Creates a new booking.
    /// </summary>
    /// <returns>The created booking.</returns>
    /// <response code="200">Returns the created booking.</response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpPost("create")]
    [ProducesResponseType(typeof(CreateBookingResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CreateBookingResponse>> CreateBookingAsync(
        [FromBody] CreateBookingDto bookingDto,
        CancellationToken cancellationToken)
    {
        CreateBookingResponse response = await _client.CreateBookingAsync(bookingDto, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Postpones an existing booking.
    /// </summary>
    /// <returns>The postponed booking.</returns>
    /// <response code="200">Returns the postponed booking.</response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpPost("postpone")]
    [ProducesResponseType(typeof(PostponeBookingResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PostponeBookingResponse>> PostponeBookingAsync(
        [FromBody] PostponeBookingDto bookingDto,
        CancellationToken cancellationToken)
    {
        PostponeBookingResponse response = await _client.PostponeBookingAsync(bookingDto, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Submits an existing booking.
    /// </summary>
    /// <returns>The submitted booking.</returns>
    /// <response code="200">Returns the submitted booking.</response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpPost("submit")]
    [ProducesResponseType(typeof(SubmitBookingResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<SubmitBookingResponse>> SubmitBookingAsync(
        [FromBody] SubmitBookingDto bookingDto,
        CancellationToken cancellationToken)
    {
        SubmitBookingResponse response = await _client.SubmitBookingAsync(bookingDto, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Completes an existing booking.
    /// </summary>
    /// <returns>The completed booking.</returns>
    /// <response code="200">Returns the completed booking.</response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpPost("complete")]
    [ProducesResponseType(typeof(CompleteBookingResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CompleteBookingResponse>> CompleteBookingAsync(
        [FromBody] CompleteBookingDto bookingDto,
        CancellationToken cancellationToken)
    {
        CompleteBookingResponse response = await _client.CompleteBookingAsync(bookingDto, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Cancels an existing booking.
    /// </summary>
    /// <returns>The cancelled booking.</returns>
    /// <response code="200">Returns the cancelled booking.</response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpPost("cancel")]
    [ProducesResponseType(typeof(CancelBookingResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CancelBookingResponse>> CancelBookingAsync(
        [FromBody] CancelBookingDto bookingDto,
        CancellationToken cancellationToken)
    {
        CancelBookingResponse response = await _client.CancelBookingAsync(bookingDto, cancellationToken);
        return Ok(response);
    }

    /// <summary>
    /// Gets available date ranges for a room.
    /// </summary>
    /// <returns>The available date ranges.</returns>
    /// <response code="200">Returns the available date ranges.</response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpGet("ranges/{roomId}")]
    [ProducesResponseType(typeof(GetRoomAvailableDateRangesResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<GetRoomAvailableDateRangesResponse>> GetRoomAvailableDateRangesAsync(
        long roomId,
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate,
        CancellationToken cancellationToken)
    {
        var dto = new GetRoomAvailableDateRangesDto(roomId, startDate, endDate);

        GetRoomAvailableDateRangesResponse response = await _client.GetRoomAvailableDateRangesAsync(dto, cancellationToken);
        return Ok(response);
    }
}