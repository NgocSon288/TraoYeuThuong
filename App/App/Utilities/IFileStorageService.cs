using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace App.Utilities
{
    public interface IFileStorageService
    {
        Task DeleteFileAsync(string fileName);
        Task<string> SaveFileAsync(IFormFile file, string savePath);
    }
}