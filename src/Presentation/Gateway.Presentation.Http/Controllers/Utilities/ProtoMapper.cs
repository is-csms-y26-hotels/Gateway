// namespace Gateway.Presentation.Http.Controllers.Utilities;
//
// public static class ProtoMapper
// {
//     public static CreateUser.Request UserDtoToCreateUserRequest(UserDto dto)
//     {
//         long id = 0;
//         if (dto.UserId is not null)
//             id = dto.UserId.Value;
//
//         string? tel = null;
//         if (dto.Tel is not null)
//             tel = dto.Tel;
//
//         var request = new CreateUser.Request
//         {
//             UserId = id,
//             FirstName = dto.FirstName,
//             LastName = dto.LastName,
//             Email = dto.Email,
//             Password = dto.Password,
//             Birthdate = dto.Birthdate,
//             Sex = dto.Sex,
//             Tel = tel,
//             CreatedAt = dto.CreatedAt,
//         };
//
//         return request;
//     }
// }