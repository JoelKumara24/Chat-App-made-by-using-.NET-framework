using ChatDataTier;
using ChatServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace ChatAppClient
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private DataserverInterface chatServer;
        //public DataserverInterface ChatServer2;
        private string selectedChatRoom;
        private User user;
        private CountClass count;
        public static Window2 chatRoomWindow;
        public int userID;

        public Window2(DataserverInterface chatServer1,User user1,CountClass count1,int uID)
        {
            InitializeComponent();
            ChannelFactory<DataserverInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();
            string URL = "net.tcp://localhost:8100/DataService";
            foobFactory = new ChannelFactory<DataserverInterface>(tcp, URL);
            chatServer = chatServer1;
            user = user1;
            PopulateChatRooms();    
            count = count1;
            chatRoomWindow = this;
            userID = uID;

            LoggedInUserTextBlock.Text = "Logged in as: " + user.Name;

        }

        public void PopulateChatRooms()
        {
            
            // Call the server to get a list of available chat rooms
            List<ChatRoom> chatRooms = chatServer.GetChatRooms();

            // Extract the names of the chat rooms
            List<string> chatRoomNames = chatRooms.Select(room => room.RoomName).ToList();

            // Bind the chat room names to the ComboBox
            ChatRoomComboBox.ItemsSource = chatRoomNames;
        }

        private void JoinChatRoomButton_Click(object sender, RoutedEventArgs e)
        {
            ChatRoom chatRoom = null;
            
            selectedChatRoom = ChatRoomComboBox.SelectedItem as string;
            
            if (!string.IsNullOrEmpty(selectedChatRoom))
            {
              
                
                //Console.WriteLine(count);


                foreach (ChatRoom chatroom1 in chatServer.GetChatRooms())
                {
                    if (selectedChatRoom == chatroom1.RoomName) { chatRoom = chatroom1; }
                }

                chatServer.addUsers(chatRoom.RoomName,user);
                //chatRoom.addUser(user);
                



                //List<Window3> instances = WindowList.GetOrCreateWindowsForChatRoom(selectedChatRoom);

                if(userID==0) 
                {
                    if (count.Count == 1)
                    {

                        Window3 FirstUser = new Window3(chatRoom, chatServer, user, chatRoomWindow,count);
                        
                        FirstUser.Show();

                    }
                    else if (count.Count == 2)
                    {

                        Window5 SecondUser = new Window5(chatRoom, chatServer, user, chatRoomWindow, count);
                        SecondUser.Show();

                    }
                    else if (count.Count == 3)
                    {

                        Window6 ThirdUser = new Window6(chatRoom, chatServer, user, chatRoomWindow, count);
                        ThirdUser.Show();

                    }
                    else if (count.Count == 4)
                    {

                        Window7 FourthUser = new Window7(chatRoom, chatServer, user, chatRoomWindow, count);
                        FourthUser.Show();

                    }
                    else if (count.Count == 5)
                    {

                        Window8 FifthUser = new Window8(chatRoom, chatServer, user, chatRoomWindow, count);
                        FifthUser.Show();

                    }
                    else
                    {
                        MessageBox.Show("Users Full");
                    }
                }
                else if (userID==1)
                {
                   /* Window3 FirstUser = new Window3(chatRoom, chatServer, user, chatRoomWindow, count);
                    FirstUser.Show();*/
                   Window3.instance.chatRoom = chatRoom;
                    
                    Window3.instance.PopulateMessages(new List<ChatMessage>());
                    Window3.instance.newGroupUsers(chatRoom);
                    Window3.instance.updateNewGroupName(chatRoom);
                   Window3.instance.Show();
                }
                else if (userID == 2)
                {
                    Window5.instance.chatRoom = chatRoom;
                    Window5.instance.PopulateMessages(new List<ChatMessage>());
                    Window5.instance.newGroupUsers(chatRoom);
                    Window5.instance.updateNewGroupName(chatRoom);
                    Window5.instance.Show();

                    /*Window5 SecondUser = new Window5(chatRoom, chatServer, user, chatRoomWindow, count);
                    SecondUser.Show();*/

                }
                else if (userID == 3)
                {
                    Window6.instance.chatRoom = chatRoom;
                    Window6.instance.PopulateMessages(new List<ChatMessage>());
                    Window6.instance.newGroupUsers(chatRoom);
                    Window6.instance.updateNewGroupName(chatRoom);
                    Window6.instance.Show();

                    /*Window6 ThirdUser = new Window6(chatRoom, chatServer, user, chatRoomWindow, count);
                    ThirdUser.Show();*/

                }
                else if (userID == 4)
                {
                    Window7.instance.chatRoom = chatRoom;
                    Window7.instance.PopulateMessages(new List<ChatMessage>());
                    Window7.instance.newGroupUsers(chatRoom);
                    Window7.instance.updateNewGroupName(chatRoom);
                    Window7.instance.Show();
                    /*Window7 FourthUser = new Window7(chatRoom, chatServer, user, chatRoomWindow, count);
                    FourthUser.Show();*/

                }
                else if (userID == 5)
                {
                    Window8.instance.chatRoom = chatRoom;
                    Window8.instance.PopulateMessages(new List<ChatMessage>());
                    Window8.instance.newGroupUsers(chatRoom);
                    Window8.instance.updateNewGroupName(chatRoom);
                    Window8.instance.Show();
                    /*Window8 FifthUser = new Window8(chatRoom, chatServer, user, chatRoomWindow , count);
                    FifthUser.Show();*/

                }



                chatRoomWindow.Close();
                this.Close();
                // Close the chat room selection window
                //Close();
            }
        }

        private void CreateChatRoomButton_Click(object sender, RoutedEventArgs e) 
        {
            chatRoomWindow.Hide();

            // Open or show the chat room selection window (Window2)
            Window4 chatRoomSelectionWindow = new Window4(chatServer,user,count,chatRoomWindow,userID);
            chatRoomSelectionWindow.Show();
        }





    }
}
