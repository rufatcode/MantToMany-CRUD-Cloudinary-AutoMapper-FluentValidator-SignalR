using System;
namespace Lab10_FrontToBack.Models
{
    public class ChatMessage : BaseEntity
    {
        public string Message { get; set; }
        public string FromUserId { get; set; }
        public AppUser FromUser { get; set; }
        public string ToUserId { get; set; }
        public AppUser ToUser { get; set; }
        public bool IsSeen { get; set; }
        public ChatMessage()
        {
        }
    }
}

