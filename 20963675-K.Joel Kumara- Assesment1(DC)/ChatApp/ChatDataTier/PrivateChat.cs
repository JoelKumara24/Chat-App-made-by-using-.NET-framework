using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataTier
{
    
    public class PrivateChat
    {
        public string User1 { get; }
        public string User2 { get; }
        public List<ChatMessage> Messages { get; } = new List<ChatMessage>();


        public PrivateChat(string user1, string user2)
        {
            User1 = user1;
            User2 = user2;
        }

        public void AddMessage(string sender, string message)
        {
            if (message != null)
            {
                ChatMessage chatMessage = new ChatMessage
                {
                    User = sender,
                    Message = message
                };

            Messages.Add(chatMessage);
            }
        }
    }

}
