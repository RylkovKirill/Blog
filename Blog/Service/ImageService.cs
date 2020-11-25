using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Blog.Service
{
    public class ImageService
    {

        public ImageService()
        {
        }

        public string Save(IFormFile imageFile, IWebHostEnvironment webHostEnvironment, string folderPath)
        {
            string path = imageFile.FileName;
            using (var stream = new FileStream(Path.Combine(webHostEnvironment.WebRootPath, folderPath, imageFile.FileName), FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }
            return path;
        }

        public void Delete(string imagePath, IWebHostEnvironment webHostEnvironment, string folderPath)
        {
            string path = Path.Combine(webHostEnvironment.WebRootPath, folderPath, imagePath);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
