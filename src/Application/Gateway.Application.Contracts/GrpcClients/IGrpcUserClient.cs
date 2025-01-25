using Users.UsersService.Contracts;

namespace Gateway.Application.Contracts.GrpcClients;

public interface IGrpcUserClient
{
    public Task<CreateUserResponse> CreateUserAsync(
        UserDto dto,
        CancellationToken cancellationToken);
}