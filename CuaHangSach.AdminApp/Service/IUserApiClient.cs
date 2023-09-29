using CuaHangSach.ViewModels.System.Users;

namespace CuaHangSach.AdminApp.Service
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);

    }
}
