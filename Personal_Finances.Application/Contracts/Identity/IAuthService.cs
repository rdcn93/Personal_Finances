using Personal_Finances.Application.Models.Identity;

namespace Personal_Finances.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Registrar(RegistrationRequest request);
    }
}
