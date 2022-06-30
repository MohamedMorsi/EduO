using EduO.Core.Dtos;

namespace EduO.Web.HttpServices.Contract
{
    public interface IAuthenticationService 
    {
        Task<RegistrationResponseDto> RegisterUser(UserRegistrationFormDto userForRegistration);
        Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication);
        Task Logout();
    }
}
