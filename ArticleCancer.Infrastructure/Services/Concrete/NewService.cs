using ArticleCancer.Application.DTOs.News;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Domain.Enums;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Infrastructure.Helpers.Images;
using ArticleCancer.Persistence.UnıtOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using NewCancer.Infrastructure.Services.Abstract;
using System.Security.Claims;

namespace ArticleCancer.Infrastructure.Services.Concrete
{
    public class NewService : INewService
    {
        private readonly IUnıtOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IImageHelper _imageHelper;
        private readonly ClaimsPrincipal _user;

        public NewService(IUnıtOfWork unitofWork, IMapper mapper, IHttpContextAccessor contextAccessor, IImageHelper imageHelper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _imageHelper = imageHelper;
            _user = _contextAccessor.HttpContext.User;
        }
        public async Task CreateNewAsync(NewAddDto newAddDto)
        {
            var map = _mapper.Map<New>(newAddDto);
            var userID = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var imageUpload = await _imageHelper.Upload(newAddDto.Title, newAddDto.Photo, ImageType.New);

            Image image = new(imageUpload.FullName, newAddDto.Photo.ContentType, userEmail);
            await _unitofWork.GetRepository<Image>().AddAsync(image);

            map.Image = image;
            map.UserID = userID;
            map.CreatedBy = userEmail;

            await _unitofWork.GetRepository<New>().AddAsync(map);
            await _unitofWork.SaveAsync();
        }

        public async Task<NewListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles = categoryId == null
                ? await _unitofWork.GetRepository<New>().GetAllAsync(a => !a.IsDeleted, a => a.Category, i => i.Image, u => u.User)
                : await _unitofWork.GetRepository<New>().GetAllAsync(a => a.CategoryID == categoryId && !a.IsDeleted,
                    a => a.Category, i => i.Image, u => u.User);
            var sortedNews = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new NewListDto
            {
                News = sortedNews,
                CategoryID = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending

            };
        }

        public async Task<List<NewDto>> GetAllNewsAsync()
        {
            var result = await _unitofWork.GetRepository<New>().GetAllAsync();
            var map = _mapper.Map<List<NewDto>>(result);
            return map;
        }

        public async Task<List<NewDto>> GetAllNewsNonDeletedTake3Async()
        {
            var news = await _unitofWork.GetRepository<New>().GetAllAsync(x => !x.IsDeleted, x => x.Image);
            var random = new Random();
            var randomNews = news.OrderBy(a => random.Next()).Take(3).ToList();
            var map = _mapper.Map<List<NewDto>>(randomNews);
            return map.Take(3).ToList();
        }

        public async Task<List<NewDto>> GetAllNewsWithCategoryDeletedAsync()
        {
            var articles = await _unitofWork.GetRepository<New>().GetAllAsync(x => x.IsDeleted, x => x.Category);
            var map = _mapper.Map<List<NewDto>>(articles);
            return map;
        }
        public async Task<List<NewDto>> GetAllNewsWithCategoryNonDeletedAsync()
        {
            var articles = await _unitofWork.GetRepository<New>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
            var map = _mapper.Map<List<NewDto>>(articles);
            return map;
        }



        public async Task<NewDto> GetNewDetailAsync(Guid newId, string ipAddress)
        {
            var article = await _unitofWork.GetRepository<New>().GetAsync(x => x.NewID == newId, x => x.User);
            var visitor = await _unitofWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == ipAddress);

            if (article == null)
            {
                return null;
            }

            var articleVisitors = await _unitofWork.GetRepository<ArticleVisitor>().GetAllAsync(null, x => x.Visitor, y => y.Article);

            var addArticleVisitors = new NewVisitor(article.NewID, visitor?.VisitorID ?? 0);

            if (!articleVisitors.Any(x => x.VisitorID == addArticleVisitors.VisitorID && x.ArticleID == addArticleVisitors.NewID))
            {
                await _unitofWork.GetRepository<NewVisitor>().AddAsync(addArticleVisitors);
                article.ViewCount += 1;
                await _unitofWork.GetRepository<New>().UpdateAsync(article);
                await _unitofWork.SaveAsync();
            }

            return await GetNewWithCategoryNonDeletedAsync(newId);
        }

        public async Task<NewDto> GetNewWithCategoryNonDeletedAsync(Guid newID)
        {
            var articles = await _unitofWork.GetRepository<New>().GetAsync(x => !x.IsDeleted && x.NewID == newID, x => x.Category, x => x.Image);
            var map = _mapper.Map<NewDto>(articles);
            return map;
        }


        public async Task<string> SafeDeleteNewAsync(Guid newID)
        {
            var userEmail = _user.GetLoggedInEmail();
            var news = await _unitofWork.GetRepository<New>().GetByGuidAsync(newID);
            news.IsDeleted = true;
            news.DeletedDate = DateTime.Now;
            news.DeletedBy = userEmail;
            await _unitofWork.GetRepository<New>().UpdateAsync(news);
            await _unitofWork.SaveAsync();

            return news.Title;
        }

        public async Task<NewListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles = await _unitofWork.GetRepository<New>().GetAllAsync(
                a => !a.IsDeleted && (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Category.Name.Contains(keyword)),
            a => a.Category, i => i.Image, u => u.User);

            var sortedNews = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new NewListDto
            {
                News = sortedNews,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }

        public async Task<string> UndoDeleteNewAsync(Guid newID)
        {
            var article = await _unitofWork.GetRepository<New>().GetByGuidAsync(newID);
            article.IsDeleted = false;
            article.DeletedDate = null;
            article.DeletedBy = null;
            await _unitofWork.GetRepository<New>().UpdateAsync(article);
            await _unitofWork.SaveAsync();

            return article.Title;
        }

        public async Task<string> UpdateNewAsync(NewUpdateDto newUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitofWork.GetRepository<New>().GetAsync(x => !x.IsDeleted && x.NewID == newUpdateDto.NewID, x => x.Category, x => x.Image);

            if (newUpdateDto.Photo != null)
            {
                _imageHelper.Delete(article.Image.FileName);
                var imageUpload = await _imageHelper.Upload(newUpdateDto.Title, newUpdateDto.Photo, ImageType.New);
                Image image = new(imageUpload.FullName, newUpdateDto.Photo.ContentType, userEmail);
                await _unitofWork.GetRepository<Image>().AddAsync(image);
                newUpdateDto.ImageID = image.ImageID;

            }
            else
            {
                if (article.Image != null)
                {
                    newUpdateDto.ImageID = article.ImageID;
                    newUpdateDto.Image = article.Image;
                }
            }

            _mapper.Map(newUpdateDto, article);
            //article.ImageID = newUpdateDto.ImageID;
            //article.CategoryID = newUpdateDto.CategoryId;
            //article.Title = newUpdateDto.Title;
            //article.Content = newUpdateDto.Content;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;
            await _unitofWork.GetRepository<New>().UpdateAsync(article);
            await _unitofWork.SaveAsync();

            return article.Title;
        }
    }
}
