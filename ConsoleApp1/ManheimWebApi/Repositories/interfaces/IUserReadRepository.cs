using ManheimWebApi.Models;

namespace ManheimWebApi.Repositories.interfaces
{
    public interface IUserReadRepository
    {
        Task<User?> GetUserByIdAsync(string id);
        Task<User?> GetUserByEmailAsync(string email);

        Task<List<User>?> GetAllUsersAsync();
    }
}
