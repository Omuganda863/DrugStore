using DrugStore.Controllers.Models;

namespace DrugStore.Services.Iservices
{
    public interface IUser
    {
        Task<List<User>> GetUsersList();
        Task<User> GetUser(Guid Id);
        Task<string> AddUser(User user);
        Task <string>DeleteUser(User user, Guid Id);
        Task<string> UpdateUser(Guid id);
        Task<User>LoginUser (User user);
    }
}
