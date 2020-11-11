using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Blog.Service
{
    public class ImageService
    {
        public string Save(IFormFile imageFile, IWebHostEnvironment webHostEnvironment)
        {
            string path = imageFile.FileName;
            using (var stream = new FileStream(Path.Combine(webHostEnvironment.WebRootPath, "images/", imageFile.FileName), FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }
            return path;
        }
    }
}
