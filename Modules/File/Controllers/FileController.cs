using Microsoft.AspNetCore.Mvc;
using MovieApi.Modules.File.Models;

namespace MovieApi.Modules.File
{
    [Route("api/files/")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<string> Upload([FromForm] Upload obj)
        {
            if (obj.File.Length > 0)
            {
                try
                {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "\\Date\\Files");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    using (FileStream fileStream = System.IO.File.Create(filePath + obj.File.FileName))
                    {
                        await obj.File.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                        return filePath + obj.File.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Upload failed";
            }
             
        }
    }
}