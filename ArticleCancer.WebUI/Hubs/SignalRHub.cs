using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Infrastructure.Services.Concrete;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;

namespace ArticleCancer.WebUI.Hubs
{
    public class SignalRHub:Hub
    {
        private readonly IContentDetailService _contentDetailService;
        private readonly IMessageService _messageService;

        public SignalRHub(IContentDetailService contentDetailService, IMessageService messageService)
        {
            _contentDetailService = contentDetailService;
            _messageService = messageService;
        }

        public async Task SendClosePage(Guid contentDetailId)
        {
            var result = await _contentDetailService.UpdateContentDetailAsync(contentDetailId);

            if (result == "Ok")
            {
                await Clients.All.SendAsync("ReceiveClosePage", contentDetailId);
            }
        }
        public async Task VideoClicked(Guid contentDetailId)
        {
            var result = await _contentDetailService.UpdateContentDetailIsWatchAsync(contentDetailId);

            if (result == "Ok")
            {
                await Clients.All.SendAsync("VideoClicked", contentDetailId);
            }
        }
       
        public async Task MessageCount()
        {
            var receiverCount = await _messageService.ReceiverMessageCountAsync();
            var senderCount = await _messageService.SenderMessageCountAsync();

            await Clients.All.SendAsync("ReceiveReceiverMessageCount", receiverCount);
            await Clients.All.SendAsync("ReceiveSenderMessageCount", senderCount);

        }
    }
}
