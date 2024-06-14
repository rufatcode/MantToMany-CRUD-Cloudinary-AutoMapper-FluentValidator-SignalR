using System;
using Microsoft.AspNetCore.Identity;

namespace Lab10_FrontToBack.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Removed { get; set; }
        public DateTime? Updated { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ChatMessage> SentMessages { get; set; }
        public ICollection<ChatMessage> ReceivedMessages { get; set; }
        public bool isOnline { get; set; }
        public string? ConnectionId { get; set; }
        public Nullable<DateTime> LastDisconnectedTime { get; set; }
        public AppUser()
        {
        }
    }
}

