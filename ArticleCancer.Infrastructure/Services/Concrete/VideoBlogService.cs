using ArticleCancer.Application.DTOs.VideoBlogs;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Domain.Enums;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Infrastructure.Helpers.Videos;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Persistence.UnıtOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ArticleCancer.Infrastructure.Services.Concrete
{
    public class VideoBlogService : IVideoBlogService
    {
        private readonly IUnıtOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IVideoHelper _videoHelper;
        private readonly ClaimsPrincipal _user;

        public VideoBlogService(IUnıtOfWork unitofWork, IMapper mapper, IHttpContextAccessor contextAccessor, IVideoHelper videoHelper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _videoHelper = videoHelper;
            _user = _contextAccessor.HttpContext.User;
        }
        public async Task CreateVideoBlogAsync(VideoBlogAddDto videoBlogAddDto)
        {
            var map = _mapper.Map<VideoBlog>(videoBlogAddDto);
            var userID = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var imageUpload = await _videoHelper.Upload(videoBlogAddDto.Title, videoBlogAddDto.Movie, VideoType.VideoBlog);

            Video video = new(imageUpload.FullName, videoBlogAddDto.Movie.ContentType, userEmail);
            await _unitofWork.GetRepository<Video>().AddAsync(video);

            map.Video = video;
            map.UserID = userID;
            map.CreatedBy = userEmail;

            await _unitofWork.GetRepository<VideoBlog>().AddAsync(map);
            await _unitofWork.SaveAsync();
        }

        public async Task<List<VideoBlogDto>> GetAllVideoBlogsAsync()
        {
            var result = await _unitofWork.GetRepository<VideoBlog>().GetAllAsync();
            var map = _mapper.Map<List<VideoBlogDto>>(result);
            return map;
        }

        public async Task<VideoBlogListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles = categoryId == null
                ? await _unitofWork.GetRepository<VideoBlog>().GetAllAsync(a => !a.IsDeleted, a => a.Category, i => i.Video, u => u.User)
                : await _unitofWork.GetRepository<VideoBlog>().GetAllAsync(a => a.CategoryID == categoryId && !a.IsDeleted,
                    a => a.Category, i => i.Video, u => u.User);
            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new VideoBlogListDto
            {
                VideoBlogs = sortedArticles,
                CategoryID = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending

            };
        }

        public async Task<List<VideoBlogDto>> GetAllVideoBlogsNonDeletedTake3Async()
        {
            var articles = await _unitofWork.GetRepository<VideoBlog>().GetAllAsync(x => !x.IsDeleted, x => x.Video);
            var random = new Random();
            var randomArticles = articles.OrderBy(a => random.Next()).Take(3).ToList();
            var map = _mapper.Map<List<VideoBlogDto>>(randomArticles);
            return map.Take(3).ToList();
        }

        public async Task<List<VideoBlogDto>> GetAllVideoBlogsWithCategoryDeletedAsync()
        {
            var articles = await _unitofWork.GetRepository<VideoBlog>().GetAllAsync(x => x.IsDeleted, x => x.Category, x => x.Video);
            var map = _mapper.Map<List<VideoBlogDto>>(articles);
            return map;
        }



        public async Task<List<VideoBlogDto>> GetAllVideoBlogsWithCategoryNonDeletedAsync()
        {
            var articles = await _unitofWork.GetRepository<VideoBlog>().GetAllAsync(x => !x.IsDeleted, x => x.Category, x => x.Video);
            var map = _mapper.Map<List<VideoBlogDto>>(articles);
            return map;
        }


        public async Task<VideoBlogDto> GetVideoBlogDetailAsync(Guid videoBlogID, string ipAddress)
        {
            var article = await _unitofWork.GetRepository<VideoBlog>().GetAsync(x => x.VideoBlogID == videoBlogID, x => x.User);
            var visitor = await _unitofWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == ipAddress);

            if (article == null)
            {
                return null;
            }

            var articleVisitors = await _unitofWork.GetRepository<ArticleVisitor>().GetAllAsync(null, x => x.Visitor, y => y.Article);

            var addArticleVisitors = new VideoBlogVisitor(article.VideoBlogID, visitor?.VisitorID ?? 0);

            if (!articleVisitors.Any(x => x.VisitorID == addArticleVisitors.VisitorID && x.ArticleID == addArticleVisitors.VideoBlogID))
            {
                await _unitofWork.GetRepository<VideoBlogVisitor>().AddAsync(addArticleVisitors);
                article.ViewCount += 1;
                await _unitofWork.GetRepository<VideoBlog>().UpdateAsync(article);
                await _unitofWork.SaveAsync();
            }

            return await GetVideoBlogWithCategoryNonDeletedAsync(videoBlogID);
        }

        public async Task<VideoBlogDto> GetVideoBlogWithCategoryNonDeletedAsync(Guid videoBlogID)
        {
            var userID = _user.GetLoggedInUserId();
            var articles = await _unitofWork.GetRepository<VideoBlog>().GetAsync(x => !x.IsDeleted && x.VideoBlogID == videoBlogID, x => x.Category, a => a.Video);
            var map = _mapper.Map<VideoBlogDto>(articles);
            return map;
        }

        public async Task<string> SafeDeleteVideoBlogAsync(Guid videoBlogID)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitofWork.GetRepository<VideoBlog>().GetByGuidAsync(videoBlogID);
            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;
            await _unitofWork.GetRepository<VideoBlog>().UpdateAsync(article);
            await _unitofWork.SaveAsync();

            return article.Title;
        }

        public async Task<VideoBlogListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles = await _unitofWork.GetRepository<VideoBlog>().GetAllAsync(
                a => !a.IsDeleted && (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Category.Name.Contains(keyword)),
            a => a.Category, i => i.Video, u => u.User);

            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return new VideoBlogListDto
            {
                VideoBlogs = sortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }

        public async Task<string> UndoDeleteVideoBlogAsync(Guid videoBlogID)
        {
            var article = await _unitofWork.GetRepository<VideoBlog>().GetByGuidAsync(videoBlogID);
            article.IsDeleted = false;
            article.DeletedDate = null;
            article.DeletedBy = null;
            await _unitofWork.GetRepository<VideoBlog>().UpdateAsync(article);
            await _unitofWork.SaveAsync();

            return article.Title;
        }

        public async Task<string> UpdateVideoBlogAsync(VideoBlogUpdateDto articleUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await _unitofWork.GetRepository<VideoBlog>().GetAsync(x => !x.IsDeleted && x.VideoBlogID == articleUpdateDto.VideoBlogID, x => x.Category, x => x.Video);

            if (articleUpdateDto.Movie != null)
            {
                _videoHelper.Delete(article.Video.FileName);
                var imageUpload = await _videoHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Movie, VideoType.VideoBlog);
                Video video = new(imageUpload.FullName, articleUpdateDto.Movie.ContentType, userEmail);
                await _unitofWork.GetRepository<Video>().AddAsync(video);
                articleUpdateDto.VideoID = video.VideoID;

            }
            else
            {
                if (article.Video != null)
                {
                    articleUpdateDto.VideoID = article.VideoID;
                    articleUpdateDto.Video = article.Video;
                }
            }

            _mapper.Map(articleUpdateDto, article);
            //article.ImageID = articleUpdateDto.ImageID;
            //article.CategoryID = articleUpdateDto.CategoryId;
            //article.Title = articleUpdateDto.Title;
            //article.Content = articleUpdateDto.Content;
            article.ModifiedDate = DateTime.Now;
            article.ModifiedBy = userEmail;
            await _unitofWork.GetRepository<VideoBlog>().UpdateAsync(article);
            await _unitofWork.SaveAsync();

            return article.Title;
        }


    }
}
