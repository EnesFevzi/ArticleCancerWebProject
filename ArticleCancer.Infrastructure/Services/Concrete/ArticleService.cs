using ArticleCancer.Application.DTOs.Articles;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Domain.Enums;
using ArticleCancer.Infrastructure.Helpers.Images;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Persistence.UnıtOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ArticleCancer.Infrastructure.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnıtOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IImageHelper _imageHelper;
        private readonly ClaimsPrincipal _user;

        public ArticleService(IUnıtOfWork unitofWork, IMapper mapper, IHttpContextAccessor contextAccessor, IImageHelper imageHelper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _imageHelper = imageHelper;
            _user = _contextAccessor.HttpContext.User;
        }

        public async Task<ArticleListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles = categoryId == null
                ? await _unitofWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted, a => a.Category, i => i.Image, u => u.User)
                : await _unitofWork.GetRepository<Article>().GetAllAsync(a => a.CategoryID == categoryId && !a.IsDeleted,
                    a => a.Category, i => i.Image, u => u.User);
            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new ArticleListDto
            {
                Articles = sortedArticles,
                CategoryID = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending

            };
        }
        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            var map = _mapper.Map<Article>(articleAddDto);
            var userID = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var imageUpload = await _imageHelper.Upload(articleAddDto.Title, articleAddDto.Photo, ImageType.Article);

            Image image = new(imageUpload.FullName, articleAddDto.Photo.ContentType, userEmail);
            await _unitofWork.GetRepository<Image>().AddAsync(image);

            map.Image = image;
            map.UserID = userID;
            map.CreatedBy = userEmail;

            await _unitofWork.GetRepository<Article>().AddAsync(map);
            await _unitofWork.SaveAsync();
        }

        public async Task<List<ArticleDto>> GetAllArticlesAsync()
        {
            var result = await _unitofWork.GetRepository<Article>().GetAllAsync();
            var map = _mapper.Map<List<ArticleDto>>(result);
            return map;
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync()
        {
            var articles = await _unitofWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category);
            var map = _mapper.Map<List<ArticleDto>>(articles);
            return map;
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedByUserAsync()
        {
            var userID = _user.GetLoggedInUserId();
            var articles = await _unitofWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted && x.UserID == userID, x => x.Category);
            var map = _mapper.Map<List<ArticleDto>>(articles);
            return map;
        }



        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var articles = await _unitofWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Category);
            var map = _mapper.Map<List<ArticleDto>>(articles);
            return map;
        }



        public async Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(Guid articleID)
        {
            var articles = await _unitofWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.ArticleID == articleID, x => x.Category, x => x.Image);
            var map = _mapper.Map<ArticleDto>(articles);
            return map;
        }



        public async Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles = await _unitofWork.GetRepository<Article>().GetAllAsync(
                a => !a.IsDeleted && (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Category.Name.Contains(keyword)),
            a => a.Category, i => i.Image, u => u.User);

            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new ArticleListDto
            {
                Articles = sortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }

        public async Task<string> UndoDeleteArticleAsync(Guid articleID)
        {
            var article = await _unitofWork.GetRepository<Article>().GetByGuidAsync(articleID);
            article.IsDeleted = false;
            article.DeletedDate = null;
            article.DeletedBy = null;
            await _unitofWork.GetRepository<Article>().UpdateAsync(article);
            await _unitofWork.SaveAsync();

            return article.Title;
        }

        public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitofWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.ArticleID == articleUpdateDto.ArticleID, x => x.Category, x => x.Image);

            if (articleUpdateDto.Photo != null)
            {
                _imageHelper.Delete(article.Image.FileName);
                var imageUpload = await _imageHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Article);
                Image image = new(imageUpload.FullName, articleUpdateDto.Photo.ContentType, userEmail);
                await _unitofWork.GetRepository<Image>().AddAsync(image);
                articleUpdateDto.ImageID = image.ImageID;

            }
            else
            {
                if (article.Image != null)
                {
                    articleUpdateDto.ImageID = article.ImageID;
                    articleUpdateDto.Image = article.Image;
                }
            }

            _mapper.Map(articleUpdateDto, article);
            //article.ImageID = articleUpdateDto.ImageID;
            //article.CategoryID = articleUpdateDto.CategoryId;
            //article.Title = articleUpdateDto.Title;
            //article.Content = articleUpdateDto.Content;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;
            await _unitofWork.GetRepository<Article>().UpdateAsync(article);
            await _unitofWork.SaveAsync();

            return article.Title;

        }
        public async Task<string> SafeDeleteArticleAsync(Guid articleID)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitofWork.GetRepository<Article>().GetByGuidAsync(articleID);
            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;
            await _unitofWork.GetRepository<Article>().UpdateAsync(article);
            await _unitofWork.SaveAsync();

            return article.Title;
        }

        public async Task<ArticleDto> GetArticleDetailAsync(Guid articleId, string ipAddress)
        {
            var article = await _unitofWork.GetRepository<Article>().GetAsync(x => x.ArticleID == articleId, x => x.User);
            var visitor = await _unitofWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == ipAddress);

            if (article == null)
            {
                return null;
            }

            var articleVisitors = await _unitofWork.GetRepository<ArticleVisitor>().GetAllAsync(null, x => x.Visitor, y => y.Article);

            var addArticleVisitors = new ArticleVisitor(article.ArticleID, visitor?.VisitorID ?? 0);

            if (!articleVisitors.Any(x => x.VisitorID == addArticleVisitors.VisitorID && x.ArticleID == addArticleVisitors.ArticleID))
            {
                await _unitofWork.GetRepository<ArticleVisitor>().AddAsync(addArticleVisitors);
                article.ViewCount += 1;
                await _unitofWork.GetRepository<Article>().UpdateAsync(article);
                await _unitofWork.SaveAsync();
            }

            return await GetArticleWithCategoryNonDeletedAsync(articleId);
        }

        public async Task<List<ArticleDto>> GetAllArticlesNonDeletedTake3Async()
        {
            var articles = await _unitofWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Image);
            var random = new Random();
            var randomArticles = articles.OrderBy(a => random.Next()).Take(3).ToList();
            var map = _mapper.Map<List<ArticleDto>>(randomArticles);
            return map.Take(3).ToList();
        }

        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedByUserAsync()
        {
            var userID = _user.GetLoggedInUserId();
            var articles = await _unitofWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted && x.UserID == userID, x => x.Category);
            var map = _mapper.Map<List<ArticleDto>>(articles);
            return map;
        }

        public async Task<ArticleDto> GetArticleWithCategoryNonDeletedByUserAsync(Guid articleID)
        {
            var userID = _user.GetLoggedInUserId();
            var articles = await _unitofWork.GetRepository<Article>().GetAsync(x => !x.IsDeleted && x.UserID == userID, x => x.Category);
            var map = _mapper.Map<ArticleDto>(articles);
            return map;
        }

        public async Task<List<ArticleDto>> GetAllArticlesNonDeletedTake6Async()
        {
            var articles = await _unitofWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted, x => x.Image);
            var random = new Random();
            var randomArticles = articles.OrderBy(a => random.Next()).Take(3).ToList();
            var map = _mapper.Map<List<ArticleDto>>(randomArticles);
            return map.Take(6).ToList();
        }
    }
}
