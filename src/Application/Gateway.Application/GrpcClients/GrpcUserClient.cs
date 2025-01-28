using Gateway.Application.Contracts;
using Gateway.Application.Contracts.GrpcClients;
using Gateway.Application.Utilities;
using Google.Protobuf.WellKnownTypes;
using Users.UsersService.Contracts;

namespace Gateway.Application.GrpcClients;

public class GrpcUserClient : IGrpcUserClient
{
    private readonly Users.UsersService.Contracts.UsersService.UsersServiceClient _client;

    public GrpcUserClient(UsersService.UsersServiceClient client)
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
            Birthdate = Timestamp.FromDateTime(dto.Birthdate.ToUniversalTime()),
            Sex = SexEnumMapper.ToProto(dto.Sex),
            Tel = dto.Tel,
            CreatedAt = Timestamp.FromDateTime(dto.CreatedAt.ToUniversalTime()),
        };

        CreateUserResponse response = await _client.CreateAsync(request, cancellationToken: cancellationToken);
        return response;
    }

    public async Task<GetUserWithoutConfidentialInfoResponse> GetUserWithoutConfidentialInfoAsync(long id, CancellationToken cancellationToken)
    {
        var request = new GetUserWithoutConfidentialInfoRequest
        {
            UserId = id,
        };

        GetUserWithoutConfidentialInfoResponse
            response = await _client.GetUserWithoutConfidentialInfoAsync(
                request,
                cancellationToken: cancellationToken);

        return response;
    }
}
