using System;
using Lab10_FrontToBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace Lab10_FrontToBack.Hubs
{
	public class ChatHub:Hub
	{
        private readonly UserManager<AppUser> _userManager;
		public ChatHub(UserManager<AppUser>userManager)
		{
            _userManager = userManager;
		}
        public async Task SendMessageAsync(string fromId,string toId,string message)
        {
             Clients.All.SendAsync("RecieveMessage", fromId, toId, message);
        }
        public override Task OnConnectedAsync()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                AppUser appUser = _userManager.FindByNameAsync(Context.User.Identity.Name).Result;
                appUser.isOnline = true;
                appUser.LastDisconnectedTime = null;
                var resoult = _userManager.UpdateAsync(appUser).Result;
                Clients.All.SendAsync("OnConnected", appUser.Id);
                
            }
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                AppUser appUser = _userManager.FindByNameAsync(Context.User.Identity.Name).Result;
                appUser.isOnline = false;
                appUser.LastDisconnectedTime = DateTime.Now;
                var resoult = _userManager.UpdateAsync(appUser).Result;
                Clients.All.SendAsync("OnDisConnected", appUser.Id,appUser.LastDisconnectedTime);

            }
            return base.OnDisconnectedAsync(exception);
        }
        public async Task SendTyping(string userId)
        {
            Clients.All.SendAsync("GetTyping", userId);
        }
    }
}

