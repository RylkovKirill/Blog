using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Blog.Service
{
    public class ImageService
    {

        public ImageService()
        {
        }

        public string Save(IFormFile imageFile, IWebHostEnvironment webHostEnvironment, string folderPath, string imageName)
        {
            string[] ContentType = imageFile.ContentType.Split(new char[] { '/' });
            imageName = imageName + "." + ContentType[1];
            using (var stream = new FileStream(Path.Combine(webHostEnvironment.WebRootPath, folderPath, imageName), FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }
            return imageName;
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
