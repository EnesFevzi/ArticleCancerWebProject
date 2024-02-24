using ArticleCancer.Application.DTOs.ApplicationUsers;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Persistence.UnıtOfWorks;
using AutoMapper;

namespace ArticleCancer.Infrastructure.Services.Concrete
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IUnıtOfWork _unıtOfWork;
        private readonly IMapper _mapper;

        public ApplicationUserService(IUnıtOfWork unıtOfWork, IMapper mapper)
        {
            _unıtOfWork = unıtOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> CreateApplicationUserAsync(AppUser appUser)
        {
            var lastRecord = await _unıtOfWork.GetRepository<ApplicationUser>()
            .GetAllAsync(x => x.UserName == appUser.UserName && x.LastLogoutTime == null);
            lastRecord.OrderByDescending(x => x.LastLoginTime);
            var record = lastRecord.FirstOrDefault();
            if (record != null)
            {
                await UpdateApplicationUserLoginTimeAsync(record.ApplicationUserID);
            }

            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser.LastLoginTime = DateTime.Now;
            applicationUser.UserName = appUser.UserName;
            applicationUser.FirstName = appUser.FirstName;
            applicationUser.LastName = appUser.LastName;
            applicationUser.FullName = $"{appUser.FirstName} {appUser.LastName}";
            await _unıtOfWork.GetRepository<ApplicationUser>().UpdateAsync(applicationUser);
            await _unıtOfWork.SaveAsync();
            return applicationUser.ApplicationUserID;
        }

        public async Task<ApplicationUserDto> GetApplicationUserByID(Guid applicationUserId)
        {
            var applicationUser = await _unıtOfWork.GetRepository<ApplicationUser>().GetAsync(x => x.ApplicationUserID == applicationUserId);
            var map = _mapper.Map<ApplicationUserDto>(applicationUser);
            return map;
        }

        public async Task<List<ApplicationUserDto>> GetAllApplicationUsersAsync()
        {
            var applicationUsers = await _unıtOfWork.GetRepository<ApplicationUser>().GetAllAsync();
            var map = _mapper.Map<List<ApplicationUserDto>>(applicationUsers);
            return map;
        }

        public async Task<string> HardDeleteApplicationUserAsync(Guid applicationUserId)
        {
            var applicationUser = await _unıtOfWork.GetRepository<ApplicationUser>().GetByGuidAsync(applicationUserId);
            await _unıtOfWork.GetRepository<ApplicationUser>().DeleteAsync(applicationUser);
            await _unıtOfWork.SaveAsync();
            return "Ok";
        }

        public async Task<string> UpdateApplicationUserAsync(Guid applicationUserID)
        {
            var applicationUser = await _unıtOfWork.GetRepository<ApplicationUser>().GetAsync(x => x.ApplicationUserID == applicationUserID);

            if (applicationUser != null)
            {
                applicationUser.LastLogoutTime = DateTime.Now;

                // Calculate LoginExitDifference in seconds
                double loginExitDifferenceInSeconds = (applicationUser.LastLogoutTime - applicationUser.LastLoginTime)?.TotalMinutes ?? 0;
                applicationUser.LoginExitDifference = Math.Round(loginExitDifferenceInSeconds, 2);

                await _unıtOfWork.GetRepository<ApplicationUser>().UpdateAsync(applicationUser);
                await _unıtOfWork.SaveAsync();

                return "Ok";
            }

            return "User not found";
        }

        public async Task<string> UpdateApplicationUserLoginTimeAsync(Guid applicationUserID)
        {
            var applicationUser = await _unıtOfWork.GetRepository<ApplicationUser>().GetAsync(x => x.ApplicationUserID == applicationUserID);

            if (applicationUser != null)
            {
                applicationUser.LastLogoutTime = DateTime.Now;

                double loginExitDifferenceInSeconds = (applicationUser.LastLogoutTime - applicationUser.LastLoginTime)?.TotalMinutes ?? 0;
                applicationUser.LoginExitDifference = Math.Round(loginExitDifferenceInSeconds, 2);

                await _unıtOfWork.GetRepository<ApplicationUser>().UpdateAsync(applicationUser);
                await _unıtOfWork.SaveAsync();

                return "Ok";
            }

            return "User not found";
        }

    }
}
