using ArticleCancer.Application.DTOs.Videos;
using ArticleCancer.Domain.Enums;
using MailKit.Net.Imap;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.Helpers.Videos
{
    public class VideoHelper : IVideoHelper
    {
        private readonly string wwwroot;
        private readonly IWebHostEnvironment _env;
        private const string videoFolder = "videos";
        private const string VideoBlogsFolder = "videoBlogs-videos";

        public VideoHelper(IWebHostEnvironment env)
        {
            _env = env;
            wwwroot = env.WebRootPath;
        }

        private string ReplaceInvalidChars(string fileName)
        {
            return fileName.Replace("İ", "I")
                 .Replace("ı", "i")
                 .Replace("Ğ", "G")
                 .Replace("ğ", "g")
                 .Replace("Ü", "U")
                 .Replace("ü", "u")
                 .Replace("ş", "s")
                 .Replace("Ş", "S")
                 .Replace("Ö", "O")
                 .Replace("ö", "o")
                 .Replace("Ç", "C")
                 .Replace("ç", "c")
                 .Replace("é", "")
                 .Replace("!", "")
                 .Replace("'", "")
                 .Replace("^", "")
                 .Replace("+", "")
                 .Replace("%", "")
                 .Replace("/", "")
                 .Replace("(", "")
                 .Replace(")", "")
                 .Replace("=", "")
                 .Replace("?", "")
                 .Replace("_", "")
                 .Replace("*", "")
                 .Replace("æ", "")
                 .Replace("ß", "")
                 .Replace("@", "")
                 .Replace("€", "")
                 .Replace("<", "")
                 .Replace(">", "")
                 .Replace("#", "")
                 .Replace("$", "")
                 .Replace("½", "")
                 .Replace("{", "")
                 .Replace("[", "")
                 .Replace("]", "")
                 .Replace("}", "")
                 .Replace(@"\", "")
                 .Replace("|", "")
                 .Replace("~", "")
                 .Replace("¨", "")
                 .Replace(",", "")
                 .Replace(";", "")
                 .Replace("`", "")
                 .Replace(".", "")
                 .Replace(":", "")
                 .Replace(" ", "");
        }

        public async Task<VideoUploadedDto> Upload(string name, IFormFile videoFile, VideoType videoType, string folderName = null)
        {
            if (videoType == VideoType.VideoBlog)
            {
                folderName = VideoBlogsFolder;
            }
           

            if (!Directory.Exists($"{wwwroot}/{videoFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{wwwroot}/{videoFolder}/{folderName}");
            }

            string oldFileName = Path.GetFileNameWithoutExtension(videoFile.FileName);
            string firstThreeCharacters = oldFileName.Substring(0, 3);
            string fileExtension = Path.GetExtension(videoFile.FileName);

            name = ReplaceInvalidChars(name);

            DateTime dateTime = DateTime.Now;

            string newFileName = $"{name}_{Guid.NewGuid()}_{firstThreeCharacters}{fileExtension}";

            //var path = Path.Combine($"{wwwroot}/{videoFile}/{folderName}", newFileName);

            var path = Path.Combine(wwwroot, videoFolder, folderName, newFileName);

            using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 4096, FileOptions.Asynchronous);
            await videoFile.CopyToAsync(stream);
            return new VideoUploadedDto()
            {
                FullName = $"{folderName}/{newFileName}"
            };
        }

        public void Delete(string videoName)
        {
            var fileToDelete = Path.Combine($"{wwwroot}/{videoFolder}/{videoName}");
            if (File.Exists(fileToDelete))
            {
                File.Delete(fileToDelete);
            }
        }
    }

}
