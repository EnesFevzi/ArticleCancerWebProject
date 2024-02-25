using ArticleCancer.Application.DTOs.Messages;
using ArticleCancer.Domain.Entities;
using ArticleCancer.Infrastructure.Extensions;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Persistence.UnıtOfWorks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ArticleCancer.Infrastructure.Services.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IUnıtOfWork _unıtOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;

        private readonly ClaimsPrincipal _user;

        public MessageService(IUnıtOfWork unıtOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserService userService, UserManager<AppUser> userManager)
        {
           _unıtOfWork = unıtOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _userService = userService;
            _userManager = userManager;
        }

        public async Task<MessageDto> GetMessageDetails(Guid messageID)
        {
            var message = await _unıtOfWork.GetRepository<Message>().GetAsync(x => !x.IsDeleted && x.MessageID == messageID, x => x.ReceiverUser, x => x.SenderUser);
            var map = _mapper.Map<MessageDto>(message);
            return map;
        }

        public async Task<List<MessageDto>> ReceiverMessageAsync()
        {
            var userID = _user.GetLoggedInUserId();
            var message = await _unıtOfWork.GetRepository<Message>().GetAllAsync(x => !x.IsDeleted && x.ReceiverUserId == userID, x => x.ReceiverUser, x => x.SenderUser);
            var map = _mapper.Map<List<MessageDto>>(message);
            return map;

        }

        public async Task<int> ReceiverMessageCountAsync()
        {
            var userID = _user.GetLoggedInUserId();
            var messageCount = await _unıtOfWork.GetRepository<Message>().CountAsync(x => !x.IsDeleted && x.ReceiverUserId == userID);
            return messageCount;
        }
        public async Task<int> SenderMessageCountAsync()
        {
            var userID = _user.GetLoggedInUserId();
            var messageCount = await _unıtOfWork.GetRepository<Message>().CountAsync(x => !x.IsDeleted && x.SenderUserId == userID);
            return messageCount;
        }

        public async Task<string> SafeDeleteMenuAsync(Guid MenuID)
        {
            var userEmail = _user.GetLoggedInEmail();
            var menu = await _unıtOfWork.GetRepository<Message>().GetByGuidAsync(MenuID);
            menu.IsDeleted = true;
            menu.DeletedDate = DateTime.Now;
            menu.DeletedBy = userEmail;
            await _unıtOfWork.GetRepository<Message>().UpdateAsync(menu);
            return menu.Subject;
        }

        public async Task<List<MessageDto>> SenderMessageAsync()
        {
            var userID = _user.GetLoggedInUserId();
            var message = await _unıtOfWork.GetRepository<Message>().GetAllAsync(x => !x.IsDeleted && x.SenderUserId == userID, x => x.ReceiverUser);
            var map = _mapper.Map<List<MessageDto>>(message);
            return map;
        }

        public async Task SendMessageAsync(SendMessageDto sendMessageDto)
        {
            var userID = _user.GetLoggedInUserId();
            var user = await _userService.GetAppUserByIdAsync(userID);
            var map = _mapper.Map<Message>(sendMessageDto);
            map.SenderUserId = userID;
            map.SenderUser = user;
            var receiverUser = await _userManager.FindByEmailAsync(sendMessageDto.ReceiverMail);
            map.ReceiverUserId = receiverUser.Id;
            map.ReceiverUser = receiverUser;
            await _unıtOfWork.GetRepository<Message>().AddAsync(map);
            await _unıtOfWork.SaveAsync();

        }

        public async Task<string> UndoDeleteMenuAsync(Guid MenuID)
        {
            var menu = await _unıtOfWork.GetRepository<Message>().GetByGuidAsync(MenuID);
            menu.IsDeleted = false;
            menu.DeletedDate = null;
            menu.DeletedBy = null;
            await _unıtOfWork.GetRepository<Message>().UpdateAsync(menu);

            return menu.Subject;
        }
    }
}
