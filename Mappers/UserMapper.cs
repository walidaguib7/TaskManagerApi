using TasksApi.Dtos.User;
using TasksApi.Models;

namespace TasksApi.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this RegisterDto dto)
        {
            return new User
            {
                Email = dto.Email,
                UserName = dto.username,
                bio = dto.bio,
                first_name = dto.first_name,
                last_name = dto.last_name,
                gender = dto.gender,
                fileId = dto.fileId,
            };
        }
    }
}
