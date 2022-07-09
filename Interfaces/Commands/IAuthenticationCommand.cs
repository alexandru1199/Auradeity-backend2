using Models.Authentication;

namespace Interfaces.Commands
{
    public interface IAuthenticationCommand
    {
        Task<string> SignUpAsync(SignupModel signupModel);
    }
}
