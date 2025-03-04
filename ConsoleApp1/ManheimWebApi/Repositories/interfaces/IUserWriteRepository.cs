using ManheimWebApi.Models;

namespace ManheimWebApi.Repositories.interfaces
{
    public interface IUserWriteRepository
    {
        Task CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(string id, User updatedUser);

        Task<bool> DeleteUserAsync(string id);
    }
}
