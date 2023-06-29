using DAL.DTO;
using DAL.Repositories;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ProjetFinalAPI
{
    public class MessageGlobalHub : Hub
    {
        private readonly IMessageGlobalRepository _messageGlobalRepository;

        public MessageGlobalHub(IMessageGlobalRepository messageGlobalRepository)
        {
            _messageGlobalRepository = messageGlobalRepository;
        }

        public async Task SendMessage()
        {
            
           // _messageGlobalRepository.AddMessageGlobal(expediteur, message);
      
            await Clients.All.SendAsync("ReceiveMessage");
        }
    }
}
