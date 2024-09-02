using ChatDataTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    [ServiceContract]
    public interface DataserverInterface
    {
        [OperationContract]
        bool Login(string username);

        [OperationContract]
        bool Logout(string username);

        [OperationContract]
        bool CreateChatRoom(string roomName);

        [OperationContract]
        List<ChatRoom> GetChatRooms();

        [OperationContract]
        bool JoinChatRoom(string roomName, string username);

        [OperationContract]
        bool LeaveChatRoom(string roomName, string username);

        [OperationContract]
        List<ChatMessage> SendMessage(string roomName, string sender, string message, ChatMessage chatMessage);

        [OperationContract]
        List<ChatMessage> GetChatMessages(string roomName);


        [OperationContract]
        void SaveFile(string fileName, byte[] fileData);


        [OperationContract]
        List<User> GetChatRoomUsers(ChatRoom chatRoom);
        [OperationContract]
        void addUsers(string roomName, User user);

        [OperationContract]
        List<ChatMessage> GetPrivateChatInstance(string user1, string user2, string message);

        [OperationContract]
        void RemoveChatUsers(string RoomName, User user);
    }
}
