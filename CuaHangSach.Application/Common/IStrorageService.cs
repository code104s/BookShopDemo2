using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangSach.Application.Common
{
    public interface IStrorageService
    {
        string GetFileUrl(string fileName);

        Task SaveFileAsync(Stream mediaBinaryStream, string fileName);

        Task DeleteFileAsync(string fileName);
    }
}
