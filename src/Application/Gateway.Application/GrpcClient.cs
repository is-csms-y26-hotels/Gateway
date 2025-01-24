using Gateway.Application.Contracts;
using Gateway.Application.Utilities;
using Google.Protobuf.WellKnownTypes;
using Users.UsersService.Contracts;

namespace Gateway.Application;

// TODO. Register in DI
public class GrpcClient : IGrpcClient
{
    private readonly Users.UsersService.Contracts.UsersService.UsersServiceClient _client;

    public GrpcClient(UsersService.UsersServiceClient client)
    {
        _client = client;
    }

    public async Task<CreateUserResponse> CreateUserAsync(
        UserDto dto,
        CancellationToken cancellationToken)
    {
        var request = new CreateUserRequest
        {
            UserId = dto.UserId,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = dto.Password,
            Birthdate = Timestamp.FromDateTime(dto.Birthdate),
            Sex = SexEnumMapper.ToProto(dto.Sex),
            Tel = dto.Tel,
            CreatedAt = Timestamp.FromDateTime(dto.CreatedAt),
        };

        CreateUserResponse response = await _client.CreateAsync(request, cancellationToken: cancellationToken);
        return response;
    }
}
