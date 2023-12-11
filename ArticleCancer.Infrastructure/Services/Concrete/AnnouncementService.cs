using ArticleCancer.Application.DTOs.Announcements;
using ArticleCancer.Application.DTOs.Articles;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Domain.Enums;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Infrastructure.Helpers.Images;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Persistence.UnıtOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static ArticleCancer.Infrastructure.ResultMessages.Messages;

namespace ArticleCancer.Infrastructure.Services.Concrete
{
	public class AnnouncementService : IAnnouncementService
	{
		private readonly IUnıtOfWork _unitofWork;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _contextAccessor;
		private readonly IImageHelper _imageHelper;
		private readonly ClaimsPrincipal _user;

		public AnnouncementService(IUnıtOfWork unitofWork, IMapper mapper, IHttpContextAccessor contextAccessor, IImageHelper imageHelper)
		{
			_unitofWork = unitofWork;
			_mapper = mapper;
			_contextAccessor = contextAccessor;
			_imageHelper = imageHelper;
			_user = _contextAccessor.HttpContext.User;
		}
		public async Task CreateAnnouncementAsync(AnnouncementAddDto announcementAddDto)
		{
			var map = _mapper.Map<Announcement>(announcementAddDto);
			var userID = _user.GetLoggedInUserId();
			var userEmail = _user.GetLoggedInEmail();
			var imageUpload = await _imageHelper.Upload(announcementAddDto.Title, announcementAddDto.Photo, ImageType.Announcement);

			Image image = new(imageUpload.FullName, announcementAddDto.Photo.ContentType, userEmail);
			await _unitofWork.GetRepository<Image>().AddAsync(image);

			map.Image = image;
			map.UserID = userID;
			map.CreatedBy = userEmail;

			await _unitofWork.GetRepository<Announcement>().AddAsync(map);
			await _unitofWork.SaveAsync();
		}

		public async Task<List<AnnouncementDto>> GetAllAnnouncementsAsync()
		{
			var result = await _unitofWork.GetRepository<Announcement>().GetAllAsync();
			var map = _mapper.Map<List<AnnouncementDto>>(result);
			return map;
		}

		public async Task<List<AnnouncementDto>> GetAllAnnouncementsDeletedAsync()
		{
			var result = await _unitofWork.GetRepository<Announcement>().GetAllAsync(x=>x.IsDeleted);
			var map = _mapper.Map<List<AnnouncementDto>>(result);
			return map;
		}

		public async Task<List<AnnouncementDto>> GetAllAnnouncementsNonDeletedAsync()
		{
			var result = await _unitofWork.GetRepository<Announcement>().GetAllAsync(x => !x.IsDeleted);
			var map = _mapper.Map<List<AnnouncementDto>>(result);
			return map;
		}

		public async Task<List<AnnouncementDto>> GetAllAnnouncementsNonDeletedTake3Async()
		{
			var articles = await _unitofWork.GetRepository<Announcement>().GetAllAsync(x => !x.IsDeleted, x => x.Image);
			var random = new Random();
			var randomArticles = articles.OrderBy(a => random.Next()).Take(3).ToList();
			var map = _mapper.Map<List<AnnouncementDto>>(randomArticles);
			return map.Take(3).ToList();
		}

		public async Task<List<AnnouncementDto>> GetAllAnnouncementsNonDeletedTake6Async()
		{
			var articles = await _unitofWork.GetRepository<Announcement>().GetAllAsync(x => !x.IsDeleted, x => x.Image);
			var random = new Random();
			var randomArticles = articles.OrderBy(a => random.Next()).Take(3).ToList();
			var map = _mapper.Map<List<AnnouncementDto>>(randomArticles);
			return map.Take(6).ToList();
		}

		public async Task<AnnouncementListDto> GetAllByPagingAsync(int currentPage = 1, int pageSize = 3, bool isAscending = false)
		{
			pageSize = pageSize > 20 ? 20 : pageSize;
			var articles = await _unitofWork.GetRepository<Announcement>().GetAllAsync(a => !a.IsDeleted, i => i.Image, u => u.User);
			
			var sortedArticles = isAscending
				? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
				: articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
			return new AnnouncementListDto
			{
				Announcements = sortedArticles,
				CurrentPage = currentPage,
				PageSize = pageSize,
				TotalCount = articles.Count,
				IsAscending = isAscending

			};
		}

		public async Task<AnnouncementDto> GetAnnouncementDetailAsync(Guid announcementId, string ipAddress)
		{
			var announcement = await _unitofWork.GetRepository<Announcement>().GetAsync(x => x.AnnouncementID == announcementId, x => x.User);
			var visitor = await _unitofWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == ipAddress);

			if (announcement == null)
			{
				return null;
			}

			var articleVisitors = await _unitofWork.GetRepository<AnnouncementVisitor>().GetAllAsync(null, x => x.Visitor, y => y.Announcement);

			var addAnnouncementVisitors = new AnnouncementVisitor(announcement.AnnouncementID, visitor?.VisitorID ?? 0);

			if (!articleVisitors.Any(x => x.VisitorID == addAnnouncementVisitors.VisitorID && x.AnnouncementID == addAnnouncementVisitors.AnnouncementID))
			{
				await _unitofWork.GetRepository<AnnouncementVisitor>().AddAsync(addAnnouncementVisitors);
				announcement.ViewCount += 1;
				await _unitofWork.GetRepository<Announcement>().UpdateAsync(announcement);
				await _unitofWork.SaveAsync();
			}

			return await GetAnnouncementNonDeletedAsync(announcementId);
		}

		public async Task<AnnouncementDto> GetAnnouncementNonDeletedAsync(Guid announcementId)
		{
			var articles = await _unitofWork.GetRepository<Announcement>().GetAsync(x => !x.IsDeleted && x.AnnouncementID == announcementId, x => x.Image);
			var map = _mapper.Map<AnnouncementDto>(articles);
			return map;
		}

		public async Task<string> SafeDeleteAnnouncementAsync(Guid announcementId)
		{
			var userEmail = _user.GetLoggedInEmail();
			var article = await _unitofWork.GetRepository<Announcement>().GetByGuidAsync(announcementId);
			article.IsDeleted = true;
			article.DeletedDate = DateTime.Now;
			article.DeletedBy = userEmail;
			await _unitofWork.GetRepository<Announcement>().UpdateAsync(article);
			await _unitofWork.SaveAsync();

			return article.Title;
		}

		public async Task<AnnouncementListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
		{
			pageSize = pageSize > 20 ? 20 : pageSize;
			var articles = await _unitofWork.GetRepository<Announcement>().GetAllAsync(
				a => !a.IsDeleted && (a.Title.Contains(keyword) || a.Content.Contains(keyword)),
			 i => i.Image, u => u.User);

			var sortedArticles = isAscending
				? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
				: articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

			return new AnnouncementListDto
			{
				Announcements = sortedArticles,
				CurrentPage = currentPage,
				PageSize = pageSize,
				TotalCount = articles.Count,
				IsAscending = isAscending
			};
		}

		public async Task<string> UndoDeleteAnnouncementAsync(Guid announcementId)
		{
			var article = await _unitofWork.GetRepository<Announcement>().GetByGuidAsync(announcementId);
			article.IsDeleted = false;
			article.DeletedDate = null;
			article.DeletedBy = null;
			await _unitofWork.GetRepository<Announcement>().UpdateAsync(article);
			await _unitofWork.SaveAsync();

			return article.Title;
		}

		public async Task<string> UpdateAnnouncementAsync(AnnouncementUpdateDto articleUpdateDto)
		{
			var userEmail = _user.GetLoggedInEmail();
			var article = await _unitofWork.GetRepository<Announcement>().GetAsync(x => !x.IsDeleted && x.AnnouncementID == articleUpdateDto.AnnouncementID, x => x.Image);

			if (articleUpdateDto.Photo != null)
			{
				_imageHelper.Delete(article.Image.FileName);
				var imageUpload = await _imageHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Announcement);
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
			await _unitofWork.GetRepository<Announcement>().UpdateAsync(article);
			await _unitofWork.SaveAsync();

			return article.Title;
		}
	}
}
