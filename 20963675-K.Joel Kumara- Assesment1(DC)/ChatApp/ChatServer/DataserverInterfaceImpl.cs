using ChatDataTier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    internal class DataserverInterfaceImpl : DataserverInterface
    {
        private UserManager userManager = new UserManager();
        private ChatRoomManager chatRoomManager = new ChatRoomManager();

        // Maintain a dictionary to store connected clients and their callbacks
       // private Dictionary<string, IChatClientCallback> connectedClients = new Dictionary<string, IChatClientCallback>();
        private Dictionary<string, PrivateChat> privateChats = new Dictionary<string, PrivateChat>();

        public bool Login(string username)
        {
            if (userManager.IsUsernameUnique(username))
            {
                userManager.AddUser(username);
                Console.WriteLine($"{username} has logged in.");

                // Create a new callback channel for the client and add it to the dictionary
                //IChatClientCallback callback = OperationContext.Current.GetCallbackChannel<IChatClientCallback>();
                //connectedClients[username] = callback;


                return true;
            }
            else
            {
                Console.WriteLine($"Login failed: {username} already exists.");
                return false;
            }
        }

        public bool Logout(string username)
        {
            if (userManager.IsUsernameUnique(username))
            {
                Console.WriteLine($"Logout failed: {username} does not exist.");
                return false;
            }
            else
            {
                userManager.RemoveUser(username);
                Console.WriteLine($"{username} has logged out.");
                return true;
            }
        }

        public bool CreateChatRoom(string roomName)
        {
           

            foreach (ChatRoom chatroom1 in chatRoomManager.GetChatRooms())
            {
                if (roomName == chatroom1.RoomName) 
                { 
                    return false; 
                }
            }
            
            

            // Create the chat room
            chatRoomManager.CreateChatRoom(roomName);
            return true;
        }

        public List<ChatRoom> GetChatRooms()
        {
            return chatRoomManager.GetChatRooms();
        }

        public bool JoinChatRoom(string roomName, string username)
        {
            return chatRoomManager.JoinChatRoom(roomName, username);
        }

        public bool LeaveChatRoom(string roomName, string username)
        {
            Console.WriteLine("Trying to Removed User");

            if (chatRoomManager.LeaveChatRoom(roomName, username))
            {
                Console.WriteLine("Removed User");
            }

            return chatRoomManager.LeaveChatRoom(roomName, username);
        }

        public List<ChatMessage> SendMessage(string roomName, string sender, string message, ChatMessage chatMessage)
        {
            Console.WriteLine(sender);
            Console.WriteLine("In the Send Messge()");
            ChatRoom chatRoom = null;
            bool chat = false;

            foreach (ChatRoom chatroom1 in chatRoomManager.GetChatRooms())
            {
                if (roomName == chatroom1.RoomName) {
                    chatRoom = chatroom1;
                    chat = true;
                    Console.WriteLine("Chat room configuration");
                }
            }
            

            if (chatRoom != null ) 
            {
                //Console.WriteLine("In the path");
                string formattedMessage = $"{sender}: {message}";
                
                
                chatRoom.ChatMessages.Add(chatMessage);

                

                foreach (ChatMessage message1 in chatRoom.ChatMessages)
                {
                    Console.WriteLine(message1);
                }

                
                foreach (User participant in chatRoom.Participants)
                {
                    
                    NotifyParticipant(participant, formattedMessage); // add a user class to the whole thing
                }
                Console.WriteLine("Returned the correct one");
                return chatRoom.ChatMessages.ToList();
            }
            Console.WriteLine("Returned the wrong one");
            return new List<ChatMessage>();
        }

        public void SendPrivateMessage(string roomName, string sender, string recipient, string message)
        {
            ChatRoom chatRoom = null;

            foreach (ChatRoom chatroom1 in chatRoomManager.GetChatRooms())
            {
                if (roomName == chatroom1.RoomName) { chatRoom = chatroom1; }
            }
            

            if (chatRoom != null && !(chatRoomManager.IsUsernameUnique(sender, chatRoom)) && !(chatRoomManager.IsUsernameUnique(recipient, chatRoom)))
            {
                // Create a private message
                PrivateMessage privateMessage = new PrivateMessage
                {
                    Sender = chatRoomManager.GetUser(sender,chatRoom),
                    Recipient = chatRoomManager.GetUser(recipient, chatRoom),
                    Content = message
                };

                // Add the private message to the chat room's private messages
                chatRoom.PrivateMessages.Add(privateMessage);

               
                NotifyParticipant(privateMessage.Recipient, $"Private message from {sender}: {message}");
            }
        }

        public void NotifyParticipant(User participant,String formattedMessage)
        {
            participant.MessageHistory.Add(formattedMessage);
        }

        // Implement a method to register a callback for a connected client
        /*public void RegisterCallback(string username)
        {
            IChatClientCallback callback = OperationContext.Current.GetCallbackChannel<IChatClientCallback>();
            connectedClients[username] = callback;
        }*/

        public List<ChatMessage> GetChatMessages(string roomName) 
        {
            return chatRoomManager.GetChatMessages(roomName);
        }



        public void SaveFile(string fileName, byte[] fileData)
        {
            string saveFilePath = Path.Combine("Downloads", fileName); // Save the file in a "Downloads" folder

            try
            {
                Directory.CreateDirectory("Downloads"); // Create the "Downloads" folder if it doesn't exist

                // Write the received file data to the specified path
                File.WriteAllBytes(saveFilePath, fileData);

                Console.WriteLine($"File saved to: {saveFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }


        public List<User> GetChatRoomUsers(ChatRoom chatRoom)
        {
            ChatRoom room = null;

            foreach (ChatRoom chatroom1 in chatRoomManager.GetChatRooms())
            {
                if (chatRoom.RoomName == chatroom1.RoomName)
                {
                    room = chatroom1;
                    
                    Console.WriteLine("ioioioio hambuna");
                }
            }
            foreach (User user in room.getUsers())
            {
                Console.WriteLine("user");
            }

            return room.getUsers().ToList();
        }

        public void RemoveChatUsers(string RoomName, User user)
        {

            if (chatRoomManager.RemoveUserFromChatRoom(RoomName, user))
            {
                Console.WriteLine("Removed User");
            }
        }

        public void addUsers(string roomName, User user) 
        {
            if(chatRoomManager.AddUserToChatRoom(roomName,user)) 
            {
                Console.WriteLine("added USER successfulyy");
            }
        }

        public List<ChatMessage> GetPrivateChatInstance(string user1, string user2,string message)
        {
            // Sort the usernames to ensure consistent chat instance creation
            var sortedUsernames = SortUsernames(user1, user2);

            // Concatenate the usernames to form a unique key for the chat instance
            string chatKey = $"{sortedUsernames.Item1}-{sortedUsernames.Item2}";

            // Check if a chat instance with this key already exists
            if (privateChats.ContainsKey(chatKey))
            {
                Console.WriteLine("Accessed the old one");
                privateChats[chatKey].AddMessage(user1,message);
                /*foreach (string message1 in privateChats[chatKey].Messages)
                {
                    Console.WriteLine(message1);
                }*/
                return privateChats[chatKey].Messages;
            }
            else
            {
                Console.WriteLine("New private chat created");
                // Create a new PrivateChat instance if it doesn't exist
                PrivateChat newChat = new PrivateChat(sortedUsernames.Item1, sortedUsernames.Item2);
                newChat.AddMessage(user1,message);
                privateChats[chatKey] = newChat;
                /*foreach (string message1 in newChat.Messages)
                {
                    Console.WriteLine(message1);
                }*/
                return newChat.Messages;
            }
        }

        // Helper method to sort two usernames alphabetically
        private Tuple<string, string> SortUsernames(string user1, string user2)
        {
            if (string.Compare(user1, user2, StringComparison.Ordinal) < 0)
            {
                return Tuple.Create(user1, user2);
            }
            else
            {
                return Tuple.Create(user2, user1);
            }
        }






    }
}
