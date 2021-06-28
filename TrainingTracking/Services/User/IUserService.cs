using TrainingTracking.Models;

namespace TrainingTracking.Services.User
{
    public interface IUserService
    {
        (string username, string token)? Authenticate(string username, string password);
        Entities.User Register(CreateUserModel user);
    }
}
