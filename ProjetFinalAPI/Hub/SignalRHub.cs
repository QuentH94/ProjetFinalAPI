using DAL.DTO;
using DAL.Repositories;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ProjetFinalAPI
{
    public class SignalRHub : Hub
    {
       

        public async Task SendMessage()
        {               
            await Clients.All.SendAsync("ReceiveNewMessageGlobal");
        }

        public async Task Login()
        {
            await Clients.All.SendAsync("UserLogin");
        }
        public async Task Logout()
        {
            await Clients.All.SendAsync("UserLogout");
        }
    }
}
