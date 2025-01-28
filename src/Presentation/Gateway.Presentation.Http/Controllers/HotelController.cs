using Gateway.Application.Contracts.GrpcClients;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Presentation.Http.Controllers;
[ApiController]
[Route("api/hotel")]
public class HotelController : ControllerBase
{
    private readonly IGrpcHotelClient _hotelClient;

    public HotelController(IGrpcHotelClient hotelClient)
    {
        _hotelClient = hotelClient;
    }

    /// <summary>
    /// Adds a new hotel.
    /// </summary>
    /// <response code="200">Hotel added</response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpPost("add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateHotel(
        [FromQuery] string hotelName,
        [FromQuery] string city,
        [FromQuery] int stars,
        CancellationToken cancellationToken)
    {
        await _hotelClient.CreateHotelAsync(hotelName, city, stars, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Updates hotel star-rating.
    /// </summary>
    /// <response code="200">Hotel rating changed</response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateHotel(
        [FromQuery] long hotelId,
        [FromQuery] int stars,
        CancellationToken cancellationToken)
    {
        await _hotelClient.UpdateHotelStarsAsync(hotelId, stars, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Soft delete hotel.
    /// </summary>
    /// <response code="200">Hotel deleted</response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteHotel(
        [FromQuery] long hotelId,
        CancellationToken cancellationToken)
    {
        await _hotelClient.SoftDeleteHotelAsync(hotelId, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Gets a hotel list by city.
    /// </summary>
    /// <returns>A list of hotels</returns>
    /// <response code="200">Returns hotel list</response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpGet("get")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetHotels(
        [FromQuery] string city,
        [FromQuery] int pageSize,
        [FromQuery] long cursor,
        CancellationToken cancellationToken)
    {
        System.Collections.ObjectModel.Collection<Application.Contracts.Dto.Hotels.HotelDto> result = await _hotelClient.GetHotelsAsync(city, pageSize, cursor, cancellationToken);
        return Ok(result);
    }
}