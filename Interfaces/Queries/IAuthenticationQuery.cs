using Models.Authentication;

namespace Interfaces.Queries
{
    public interface IAuthenticationQuery
    {
        Task<string> LoginIfUserExistsAsync(LoginModel loginModel);
    }
}
