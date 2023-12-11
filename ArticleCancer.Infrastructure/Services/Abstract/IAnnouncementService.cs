using ArticleCancer.Application.DTOs.Announcements;
using ArticleCancer.Application.DTOs.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.Services.Abstract
{
	public interface IAnnouncementService
	{
		Task<List<AnnouncementDto>> GetAllAnnouncementsAsync();
		Task<List<AnnouncementDto>> GetAllAnnouncementsNonDeletedAsync();
		Task<List<AnnouncementDto>> GetAllAnnouncementsDeletedAsync();
		Task<AnnouncementDto> GetAnnouncementNonDeletedAsync(Guid announcementId);

		Task CreateAnnouncementAsync(AnnouncementAddDto articleAddDto);
		Task<string> UpdateAnnouncementAsync(AnnouncementUpdateDto articleUpdateDto);
		Task<string> SafeDeleteAnnouncementAsync(Guid announcementId);
		Task<string> UndoDeleteAnnouncementAsync(Guid announcementId);
		Task<AnnouncementListDto> GetAllByPagingAsync(int currentPage = 1, int pageSize = 3,
			bool isAscending = false);

		Task<AnnouncementListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3,
			bool isAscending = false);

		Task<AnnouncementDto> GetAnnouncementDetailAsync(Guid announcementId, string ipAddress);

		Task<List<AnnouncementDto>> GetAllAnnouncementsNonDeletedTake3Async();
		Task<List<AnnouncementDto>> GetAllAnnouncementsNonDeletedTake6Async();
	}
}
