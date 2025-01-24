using System.Text.Json.Serialization;

namespace Gateway.Application.Contracts;

public record UserDto(
    long? UserId,
    string FirstName,
    string LastName,
    string Email,
    string Password,
    DateTime Birthdate,
    Sex Sex,
    string? Tel,
    DateTime CreatedAt)
{
    [JsonConstructor]
    public UserDto(
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime birthdate,
        Sex sex,
        DateTime createdAt)
        : this(
            null,
            firstName,
            lastName,
            email,
            password,
            birthdate,
            sex,
            null,
            createdAt)
    {
    }
}