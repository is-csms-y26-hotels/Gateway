using Gateway.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Presentation.Http.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IGrpcClient _client;

    public UserController(IGrpcClient client)
    {
        _client = client;
    }

    /// <summary>
    /// Reqisters a new user.
    /// </summary>
    /// <returns>The registered user.</returns>
    /// <response code="200">Returns the registered user.</response>
    /// <response code="400">If the input is invalid.</response>
    /// <response code="500">If an unexpected error occurs.</response>
    [HttpPost("register")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<UserDto>> RegisterUserAsync(
        [FromBody] UserDto userDto,
        CancellationToken cancellationToken)
    {
        // TODO. Retuern User instead of id?
        CreateUserResponse response = await _client.CreateUserAsync(userDto, cancellationToken: cancellationToken);
        return response;
    }
}
