using System;
namespace Lab10_FrontToBack.Services.Interfaces
{
	public interface IFileService
	{
        public bool IsImage(IFormFile file);
        public bool IsLengthSuit(IFormFile file, int value);
        public string CreateImage(IFormFile file);
        public void DeleteImage(string fileName);
    }
}

