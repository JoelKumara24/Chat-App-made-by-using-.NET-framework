using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ChatDataTier;
using ChatServer;

namespace ChatAppClient
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        private DataserverInterface chatServer;
        private User user;
        private CountClass countClass;
        private Window2 previousWindow;
        private int userID;
        List<ChatRoom> rooms = new List<ChatRoom>();

        public Window4(DataserverInterface serverClient,User user1,CountClass count, Window2 prevWindow,int uID)
        {
            InitializeComponent();
            chatServer = serverClient;
            user = user1;
            countClass = count;
            previousWindow = prevWindow;
            userID = uID;
            rooms = chatServer.GetChatRooms();
            ExistingChatRoomsListBox.DisplayMemberPath = "RoomName";
            ExistingChatRoomsListBox.ItemsSource = rooms;

        }

        private void CreateChatRoomButton_Click(object sender, RoutedEventArgs e)
        {
            string chatRoomName = ChatRoomNameTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(chatRoomName))
            {
                // Call the server to create the chat room (implement this based on your WCF setup)
                bool creationResult = chatServer.CreateChatRoom(chatRoomName);

                if (creationResult)
                {
                    MessageBox.Show("Chat room created successfully!");
                    

                    // Close the current window (CreateChatRoomWindow)
                    this.Close();

                    // Open or show the chat room selection window (Window2)
                    //Window2 chatRoomSelectionWindow = new Window2(chatServer,user,countClass);
                   // previousWindow.PopulateChatRooms();
                   // previousWindow.Show();
                    Window2 chatRoomSelectionWindow = new Window2(chatServer, user, countClass, userID);
                    chatRoomSelectionWindow.Show();
                }
                else
                {
                    MessageBox.Show("Failed to create the chat room. Chat room name may already exist.");
                }
            }
        }
    }
}
