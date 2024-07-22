using TasksApi.Models;

namespace TasksApi.Services
{
    public interface IToken
    {
        string CreateToken(User user);
    }
}
