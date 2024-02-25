using ArticleCancer.Application.DTOs.ApplicationUsers;
using ArticleCancer.Application.DTOs.ContentDetails;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Persistence.UnıtOfWorks;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.Services.Concrete
{
    public class ContentDetailService : IContentDetailService
    {
        private readonly IUnıtOfWork _unıtOfWork;
        private readonly IMapper _mapper;

        public ContentDetailService(IUnıtOfWork unıtOfWork, IMapper mapper)
        {
            _unıtOfWork = unıtOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> CreateContentDetailAsync(AppUser appUser, string contentType)
        {
            var lastRecord = await _unıtOfWork.GetRepository<ContentDetail>()
            .GetAllAsync(x => x.UserName == appUser.UserName && x.LastLogoutTime == null);
            lastRecord.OrderByDescending(x => x.LastLoginTime);
            var record = lastRecord.FirstOrDefault();
            if (record != null)
            {
                //  await UpdateApplicationUserLoginTimeAsync(record.ApplicationUserID);
            }

            ContentDetail contentDetail = new();
            contentDetail.LastLoginTime = DateTime.Now;
            contentDetail.UserName = appUser.UserName;
            contentDetail.FirstName = appUser.FirstName;
            contentDetail.LastName = appUser.LastName;
            contentDetail.FullName = $"{appUser.FirstName} {appUser.LastName}";
            contentDetail.ContentType = contentType;
            await _unıtOfWork.GetRepository<ContentDetail>().UpdateAsync(contentDetail);
            await _unıtOfWork.SaveAsync();
            return contentDetail.ContentDetailID;
        }



        public async Task<List<ContentDetailDto>> GetAllApplicationUsersAsync()
        {
            var contentDetails = await _unıtOfWork.GetRepository<ContentDetail>().GetAllAsync();
            var map = _mapper.Map<List<ContentDetailDto>>(contentDetails);
            return map;
        }

        public async Task<ContentDetailDto> GetContentDetailByID(Guid contentDetailId)
        {
            var contentDetail = await _unıtOfWork.GetRepository<ContentDetail>().GetAsync(x => x.ContentDetailID == contentDetailId);
            var map = _mapper.Map<ContentDetailDto>(contentDetail);
            return map;
        }

        public async Task<string> HardDeleteContentDetailAsync(Guid contentDetailId)
        {
            var contentDetail = await _unıtOfWork.GetRepository<ContentDetail>().GetByGuidAsync(contentDetailId);
            await _unıtOfWork.GetRepository<ContentDetail>().DeleteAsync(contentDetail);
            await _unıtOfWork.SaveAsync();
            return "Ok";
        }

        public async Task<string> UpdateContentDetailAsync(Guid contentDetailId)
        {

            var contentDetail = await _unıtOfWork.GetRepository<ContentDetail>().GetAsync(x => x.ContentDetailID == contentDetailId);

            if (contentDetail != null)
            {
                contentDetail.LastLogoutTime = DateTime.Now;

                // Calculate LoginExitDifference in seconds
                double loginExitDifferenceInSeconds = (contentDetail.LastLogoutTime - contentDetail.LastLoginTime)?.TotalMinutes ?? 0;
                contentDetail.LoginExitDifference = Math.Round(loginExitDifferenceInSeconds, 2);

                await _unıtOfWork.GetRepository<ContentDetail>().UpdateAsync(contentDetail);
                await _unıtOfWork.SaveAsync();

                return "Ok";
            }

            return "User not found";
        }

        public async Task<string> UpdateContentDetailLoginTimeAsync(Guid contentDetailId)
        {
            var contentDetail = await _unıtOfWork.GetRepository<ContentDetail>().GetAsync(x => x.ContentDetailID == contentDetailId);

            if (contentDetail != null)
            {
                contentDetail.LastLogoutTime = DateTime.Now;

                double loginExitDifferenceInSeconds = (contentDetail.LastLogoutTime - contentDetail.LastLoginTime)?.TotalMinutes ?? 0;
                contentDetail.LoginExitDifference = Math.Round(loginExitDifferenceInSeconds, 2);

                await _unıtOfWork.GetRepository<ContentDetail>().UpdateAsync(contentDetail);
                await _unıtOfWork.SaveAsync();

                return "Ok";
            }

            return "User not found";
        }
        public async Task<string> UpdateContentDetailIsWatchAsync(Guid contentDetailId)
        {
            var contentDetail = await _unıtOfWork.GetRepository<ContentDetail>().GetAsync(x => x.ContentDetailID == contentDetailId);

            if (contentDetail != null)
            {
                if (contentDetail.IsWatched == null)
                {
                    contentDetail.IsWatched = true;
                    await _unıtOfWork.GetRepository<ContentDetail>().UpdateAsync(contentDetail);
                    await _unıtOfWork.SaveAsync();

                    return "Ok";
                }

            }

            return "User not found";
        }
    }
}
