using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Duplicates.Api.Extensions
{
    public static class FileExtensions
    {
        public static async Task<byte[]> GetBytes(this IFormFile formFile)
        {
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }
    }
}