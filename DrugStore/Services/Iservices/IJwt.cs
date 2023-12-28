using DrugStore.Controllers.Models;

namespace DrugStore.Services.Iservices
{
    public interface IJwt
    {
        string GenerateToken(User user);
    }
}
