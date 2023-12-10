using ArticleCancer.Application.DTOs.Abouts;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Domain.Enums;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Infrastructure.Helpers.Images;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Persistence.UnıtOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using static ArticleCancer.Infrastructure.ResultMessages.Messages;

namespace ArticleCancer.Infrastructure.Services.Concrete
{
    public class AboutService : IAboutService
    {
        private readonly IUnıtOfWork _unıtOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IImageHelper _imageHelper;
        private readonly IMapper _mapper;
        private readonly ClaimsPrincipal _user;

        public AboutService(IUnıtOfWork unıtOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor,IImageHelper imageHelper)
        {
            _unıtOfWork = unıtOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = _httpContextAccessor.HttpContext.User;
            _imageHelper = imageHelper;
        }
        public async Task CreateAboutAsync(AboutAddDto aboutAddDto)
        {
            var map = _mapper.Map<About>(aboutAddDto);
            var userID = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var imageUpload = await _imageHelper.Upload(aboutAddDto.Title, aboutAddDto.Photo, ImageType.About);

            Image image = new(imageUpload.FullName, aboutAddDto.Photo.ContentType, userEmail);
            await _unıtOfWork.GetRepository<Image>().AddAsync(image);

            map.Image = image;
            map.CreatedBy = userEmail;

            await _unıtOfWork.GetRepository<About>().AddAsync(map);
            await _unıtOfWork.SaveAsync();
        }

        public async Task<AboutDto> GetABoutByID(Guid aboutId)
        {
            var about = await _unıtOfWork.GetRepository<About>().GetAsync(x => x.AboutID == aboutId,x=>x.Image);
            var map = _mapper.Map<AboutDto>(about);
            return map;
        }

        public async Task<List<AboutDto>> GetAllAboutsAsync()
        {
            var categories = await _unıtOfWork.GetRepository<About>().GetAllAsync(x => !x.IsDeleted,x=>x.Image);
            var map = _mapper.Map<List<AboutDto>>(categories);
            return map;
        }

        public async Task<string> HardDeleteAboutAsync(Guid aboutId)
        {
            var about = await _unıtOfWork.GetRepository<About>().GetByGuidAsync(aboutId);
            await _unıtOfWork.GetRepository<About>().DeleteAsync(about);
            await _unıtOfWork.SaveAsync();
            return about.Title;
        }

        public async Task<string> UpdateAboutAsync(AboutUpdateDto aboutUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unıtOfWork.GetRepository<About>().GetAsync(x => !x.IsDeleted && x.AboutID == aboutUpdateDto.AboutID, 
                x => x.Image);

            if (aboutUpdateDto.Photo != null)
            {
                _imageHelper.Delete(article.Image.FileName);
                var imageUpload = await _imageHelper.Upload(aboutUpdateDto.Title, aboutUpdateDto.Photo, ImageType.About);
                Image image = new(imageUpload.FullName, aboutUpdateDto.Photo.ContentType, userEmail);
                await _unıtOfWork.GetRepository<Image>().AddAsync(image);
                aboutUpdateDto.ImageID = image.ImageID;

            }
            else
            {
                if (article.Image != null)
                {
                    aboutUpdateDto.ImageID = article.ImageID;
                    aboutUpdateDto.Image = article.Image;
                }
            }

            _mapper.Map(aboutUpdateDto, article);
            //article.ImageID = articleUpdateDto.ImageID;
            //article.CategoryID = articleUpdateDto.CategoryId;
            //article.Title = articleUpdateDto.Title;
            //article.Content = articleUpdateDto.Content;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;
            await _unıtOfWork.GetRepository<About>().UpdateAsync(article);
            await _unıtOfWork.SaveAsync();

            return article.Title;
        }
    }
}
