﻿using System;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Lab10_FrontToBack.Configurations;
using Lab10_FrontToBack.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Lab10_FrontToBack.Services
{
	public class PhotoAccessor:IPhotoAccessor
	{
        private readonly Cloudinary _cloudinary;
        public PhotoAccessor(IOptions<CloudinarySettings> config)
        {
            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
                );
            _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> AddPhoto(IFormFile file)
        {
            try
            {
                var uploadResoult = new ImageUploadResult();
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Gravity("face")
                };
                uploadResoult = await _cloudinary.UploadAsync(uploadParams);
                return uploadResoult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DeletionResult> DeletePhoto(string publicId)
        {
            try
            {
                var deleteparams = new DeletionParams(publicId);
                var resoult = await _cloudinary.DestroyAsync(deleteparams);
                return resoult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public PhotoAccessor()
		{
		}
	}
}

