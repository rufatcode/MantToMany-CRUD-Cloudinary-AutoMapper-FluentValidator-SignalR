using System;
using Lab10_FrontToBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace Lab10_FrontToBack.Hubs
{
	public class DemoHub:Hub
	{
        private readonly UserManager<AppUser> _userManager;
		public DemoHub(UserManager<AppUser>userManager)
		{
            _userManager = userManager;
		}
        public async Task SendMessage(string userId,string message)
        {
            await Clients.All.SendAsync("RecieveMessage", userId, message);
        }
        public async Task SendTyping(string userId)
        {
            await Clients.All.SendAsync("recieveTyping", userId);
        }
        public override  Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                AppUser appUser =  _userManager.FindByNameAsync(Context.User.Identity.Name).Result;
                appUser.ConnectionId = Context.ConnectionId;
                appUser.isOnline = true;
                var resoult= _userManager.UpdateAsync(appUser).Result;
                Clients.All.SendAsync("OnConnect", appUser.Id);
            }
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                AppUser appUser = _userManager.FindByNameAsync(Context.User.Identity.Name).Result;
                appUser.ConnectionId = null;
                appUser.isOnline = false;
                var resoult = _userManager.UpdateAsync(appUser).Result;
                Clients.All.SendAsync("OnDisConnect", appUser.Id);
            }
            return base.OnDisconnectedAsync(exception);
        }
    }
}

