using System.Text.Json.Serialization;

namespace Gateway.Application.Contracts;

public record UserDto(
    [property: JsonPropertyName("userId")] long? UserId,
    [property: JsonPropertyName("firstName")] string FirstName,
    [property: JsonPropertyName("lastName")] string LastName,
    [property: JsonPropertyName("email")] string Email,
    [property: JsonPropertyName("password")] string Password,
    [property: JsonPropertyName("birthdate")] DateTime Birthdate,
    [property: JsonPropertyName("sex")] Sex Sex,
    [property: JsonPropertyName("tel")] string? Tel,
    [property: JsonPropertyName("createdAt")] DateTime CreatedAt)
{
    // [JsonConstructor]
    // public UserDto(
    //     long userId,
    //     string firstName,
    //     string lastName,
    //     string email,
    //     string password,
    //     DateTime birthdate,
    //     Sex sex,
    //     DateTime createdAt)
    //     : this(
    //         null,
    //         firstName,
    //         lastName,
    //         email,
    //         password,
    //         birthdate,
    //         sex,
    //         null,
    //         createdAt)
    // {
    // }
}
