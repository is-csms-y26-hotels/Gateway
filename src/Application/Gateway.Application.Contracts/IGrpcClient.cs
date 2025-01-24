namespace Gateway.Application.Contracts;

public interface IGrpcClient
{
    public Task<CreateUserResponse> CreateUserAsync(
        UserDto dto,
        CancellationToken cancellationToken);
}