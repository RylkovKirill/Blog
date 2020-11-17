using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Blog.Service
{
    public class ImageService
    {
        private readonly IConfiguration _configuration;

        public ImageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Save(IFormFile imageFile, IWebHostEnvironment webHostEnvironment)
        {
            string path = imageFile.FileName;
            using (var stream = new FileStream(Path.Combine(webHostEnvironment.WebRootPath, _configuration["ImagePath"], imageFile.FileName), FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }
            return path;
        }

        public void Delete(string imagePath, IWebHostEnvironment webHostEnvironment)
        {
            string path = Path.Combine(webHostEnvironment.WebRootPath, _configuration["ImagePath"], imagePath);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
