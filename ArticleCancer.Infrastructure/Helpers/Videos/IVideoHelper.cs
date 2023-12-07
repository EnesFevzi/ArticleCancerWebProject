using ArticleCancer.Application.DTOs.Images;
using ArticleCancer.Application.DTOs.Videos;
using ArticleCancer.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.Helpers.Videos
{
    public interface IVideoHelper
    {
        Task<VideoUploadedDto> Upload(string name, IFormFile videoFile, VideoType videoType, string folderName = null);
        void Delete(string imageName);
    }
}
