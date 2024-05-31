using System;
using CloudinaryDotNet.Actions;

namespace Lab10_FrontToBack.Services.Interfaces
{
	public interface IPhotoAccessor
	{
        Task<ImageUploadResult> AddPhoto(IFormFile file);
        Task<DeletionResult> DeletePhoto(string publicId);
    }
}

