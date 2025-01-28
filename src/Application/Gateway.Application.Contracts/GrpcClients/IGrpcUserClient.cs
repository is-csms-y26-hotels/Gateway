using Users.UsersService.Contracts;

namespace Gateway.Application.Contracts.GrpcClients;

public interface IGrpcUserClient
{
    public Task<CreateUserResponse> CreateUserAsync(
        UserDto dto,
        CancellationToken cancellationToken);

    public Task<GetUserWithoutConfidentialInfoResponse> GetUserWithoutConfidentialInfoAsync(
        long id,
        CancellationToken cancellationToken);
}