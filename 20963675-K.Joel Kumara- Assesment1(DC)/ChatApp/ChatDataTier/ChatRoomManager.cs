using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataTier
{
    public class ChatRoomManager
    {
        private List<ChatRoom> chatRooms = new List<ChatRoom>();

        public List<ChatRoom> GetChatRooms()
        {
            return chatRooms;
        }

        public void CreateChatRoom(string roomName)
        {
            ChatRoom chatRoom = new ChatRoom { RoomName = roomName };
            chatRooms.Add(chatRoom);
        }

        public bool JoinChatRoom(string roomName, string username)
        {
            ChatRoom chatRoom = null;

            foreach (ChatRoom chatroom1 in chatRooms)
            {
                if(roomName==chatroom1.RoomName) { chatRoom = chatroom1; }
            }
            if (chatRoom != null && IsUsernameUnique(username,chatRoom))
            {
                User user = new User { Name = username };
                chatRoom.Participants.Add(user);
                return true;
            }
            return false;
        }

        public bool LeaveChatRoom(string roomName, string username)
        {
            ChatRoom chatRoom = null;

            foreach (ChatRoom chatroom1 in chatRooms)
            {
                if (roomName == chatroom1.RoomName) { chatRoom = chatroom1; }
            }
            if (chatRoom != null && IsUsernameUnique(username, chatRoom))
            {
                User user = new User { Name = username };
                chatRoom.Participants.Remove(user);
                return true;
            }
            return false;
        }

        public bool IsUsernameUnique(string username,ChatRoom chatRoom)
        {



            foreach (User user1 in chatRoom.Participants)
            {
                if (username == user1.Name) { return false; }
            }



            return true;
        }

        

        public User GetUser(string username, ChatRoom chatRoom) 
        {
            User user = null;
            foreach (User user1 in chatRoom.Participants)
            {
                if (username == user1.Name) { user = user1; }
            }
            return user;
        }

        public List<ChatMessage> GetChatMessages(string roomName)
        {
            ChatRoom chatRoom = chatRooms.FirstOrDefault(room => room.RoomName == roomName);

            if (chatRoom != null)
            {
                return chatRoom.ChatMessages.ToList();
            }

            // Return an empty list or handle the case when the room is not found
            return new List<ChatMessage>();
        }

        public List<User> GetChatRoomUsers(string roomName)
        {
            ChatRoom chatRoom = chatRooms.FirstOrDefault(room => room.RoomName == roomName);

            if (chatRoom != null)
            {
                return chatRoom.Participants;
            }

            return new List<User>();
        }

        public bool AddUserToChatRoom(string roomName, User user)
        {
            ChatRoom chatRoom = chatRooms.FirstOrDefault(room => room.RoomName == roomName);

            if (chatRoom != null)
            {
                chatRoom.Participants.Add(user);
                return true; // User added successfully
            }

            return false; // Chat room not found
        }

        public bool RemoveUserFromChatRoom(string roomName, User user)
        {
            ChatRoom chatRoom = chatRooms.FirstOrDefault(room => room.RoomName == roomName);
            Console.WriteLine("Found the room");

            if (chatRoom != null)
            {
                int removedCount = chatRoom.Participants.RemoveAll(u => u.Name == user.Name);
                Console.WriteLine($"Removed {removedCount} user(s) named {user.Name}");

                // Return true if at least one user was successfully removed, false otherwise
                return removedCount > 0;
            }

            return false; // Chat room not found
        }



    }

}
