﻿using CuaHangSach.ViewModels.Common;
using CuaHangSach.ViewModels.System.Users;

namespace CuaHangSach.AdminApp.Service
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
		Task<PagedResult<UserVm>> GetUsersPagings(GetUserPagingRequest request);
        Task<bool> RegisterUser(RegisterRequest registerRequest);

	}
}
