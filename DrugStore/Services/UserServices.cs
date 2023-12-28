using DrugStore.Controllers.Models;
using DrugStore.Data;
using DrugStore.Services.Iservices;
using Microsoft.EntityFrameworkCore;

namespace DrugStore.Services
{
    public class UserServices : IUser
    {
        private readonly ApplicationDbContext _database;
        public UserServices(ApplicationDbContext context)
        {
            _database = context;
            
        }
        public async Task<string> AddUser(User user)
        {
            await _database.AddAsync(user);
            await _database.SaveChangesAsync();
            return "User Added Successfully";
        }

        public async Task<string> DeleteUser(User user, Guid id)
        {
            var ToDelete = await _database.users.Where(user=>user.Id== id).FirstOrDefaultAsync();
            if (ToDelete == null)
            {
                return "User not found";
            }
             _database.users.Remove(ToDelete);
            await _database.SaveChangesAsync();
            
            return "Use deleted succcessfully";
        }

        public async Task<User> GetUser(Guid Id)
        {
            var checkuser = await _database.users.Where(x=> x.Id== Id).FirstOrDefaultAsync();  
            if(checkuser == null)
            {
                return new User();
            }
            return checkuser;
        }

        public async Task<List<User>> GetUsersList()
        {
            return await _database.users.ToListAsync();
        }

        public Task<User> LoginUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateUser(Guid id)
        {
            var checkuser = await _database.users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (checkuser == null)
            {
                return "User not found";
            }
            _database.users.Add(checkuser);
            await _database.SaveChangesAsync();
            return "User saved successfully";
        }
    }
}
