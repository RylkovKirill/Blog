using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
