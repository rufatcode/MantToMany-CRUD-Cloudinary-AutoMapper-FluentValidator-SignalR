using System;
using Lab10_FrontToBack.Services.Interfaces;

namespace Lab10_FrontToBack.Services
{
	public class FileService: IFileService
    {
        private readonly IWebHostEnvironment _webHostEnviorment;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnviorment = webHostEnvironment;
        }

        public string CreateImage(IFormFile file)
        {
            try
            {
                string fileName = Guid.NewGuid().ToString() + ".jpeg";
                string path = Path.Combine(_webHostEnviorment.WebRootPath, "images", fileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return fileName;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteImage(string fileName)
        {
            try
            {
                if (System.IO.File.Exists(Path.Combine(_webHostEnviorment.WebRootPath, "images", fileName)))
                {
                    System.IO.File.Delete(Path.Combine(_webHostEnviorment.WebRootPath, "images", fileName));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsImage(IFormFile file)
        {
            try
            {
                return file.ContentType.Contains("image") ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IsLengthSuit(IFormFile file, int value)
        {
            try
            {
                return file.Length / 1024 < value ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

