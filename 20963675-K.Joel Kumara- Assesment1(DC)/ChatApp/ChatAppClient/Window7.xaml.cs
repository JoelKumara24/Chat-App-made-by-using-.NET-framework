using ChatDataTier;
using ChatServer;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Path = System.IO.Path;

namespace ChatAppClient
{
    /// <summary>
    /// Interaction logic for Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
        private DataserverInterface chatServer;
        public ChatRoom chatRoom;
        public User user;
        //private ChatClientCallback callback;
        public static Window7 instance;
        public ListView lv1;
        public static List<Window3> instances;
        private Window2 previousWindow;
        private CountClass countClass;
        public ListBox listBox;

        List<ChatMessage> temp = new List<ChatMessage>();
        List<User> userList = new List<User>();
        String files = "";
        User selectedUser;





        public Window7(ChatRoom chatRoom1, DataserverInterface chatServer1, User user, Window2 prevWindow, CountClass count)
        {
            InitializeComponent();
            ChannelFactory<DataserverInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();
            string URL = "net.tcp://localhost:8100/DataService";
            foobFactory = new ChannelFactory<DataserverInterface>(tcp, URL);
            chatServer = chatServer1;
            chatRoom = chatRoom1;
            // Set the DataContext to the chatRoom object
            DataContext = chatRoom;
            ChatRoomNameTextBlock.Text = chatRoom.RoomName;
            this.user = user;
            instance = this;
            previousWindow = prevWindow;
            countClass = count;
            //instances = instances1;
            //instances.Add(this);
           // listBox = UserListBox;


            //callback = new ChatClientCallback(this);
            //chatServer.RegisterCallback(callback);
          //  lv1 = ChatMessagesListView;
            //lv1.ItemsSource = chatRoom.ChatMessages;
            PopulateUserListBox();
            PopulateMessages(temp);
            reloadUsers();


        }


        public void updateNewGroupName(ChatRoom inChatRoom)
        {
            ChatRoomNameTextBlock.Text = inChatRoom.RoomName;
        }

        public void newGroupUsers(ChatRoom inChatRoom)
        {
            userBox.Document = new FlowDocument();
            userList = chatServer.GetChatRoomUsers(inChatRoom);

            foreach (User user in userList)
            {

                var userName = user.Name;
                //  var message = lis.Message;

                // Check if the message is a URL


                Run run = new Run(userName);
                // Create a clickable link for the shared file
                var hyperlink = new Hyperlink(run);
                hyperlink.TextDecorations = null;


                hyperlink.MouseLeftButtonDown += (sender, e) =>
                {
                    try
                    {
                        // Open the file using the default program
                        selectedUser = user;

                        directMsgBut.Background = Brushes.LightBlue;
                        e.Handled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error setting user: {ex.Message}");
                    }
                };



                Paragraph usernameParagraph = new Paragraph(hyperlink);


                usernameParagraph.MouseEnter += (sender, e) =>
                {
                    // Change the background color when the mouse enters the paragraph
                    usernameParagraph.Background = Brushes.LightGray;

                    Mouse.OverrideCursor = Cursors.Hand;
                };

                usernameParagraph.MouseLeave += (sender, e) =>
                {
                    // Restore the default background color when the mouse leaves the paragraph
                    usernameParagraph.Background = Brushes.Transparent;
                    Mouse.OverrideCursor = null;
                };
                userBox.Document.Blocks.Add(usernameParagraph);



            }

        }

        private void AttachFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();


            openFileDialog.Filter = "All Files (*.*)|*.*"; // Allow all file types to be selected
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Set the initial directory

            if (openFileDialog.ShowDialog() == true)
            {
                // User selected a file
                string selectedFilePath = openFileDialog.FileName;
                // Now you can use the 'selectedFilePath' to work with the selected file.

                // For example, display the selected file's name in a TextBox
                //FileNameTextBox.Text = System.IO.Path.GetFileName(selectedFilePath);

                files = files + Path.GetFileName(selectedFilePath);

                // Read the selected file into a byte array
                byte[] fileData = File.ReadAllBytes(selectedFilePath);

                // Call the SaveSharedFile function to save the file
                chatServer.SaveFile(Path.GetFileName(selectedFilePath), fileData);

                string fullPath;

                fullPath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..");
                fullPath = fullPath + "\\ChatServer\\bin\\Debug\\Downloads\\" + Path.GetFileName(selectedFilePath);
                ChatMessage chatMessage = new ChatMessage { User = user.Name, Message = fullPath };
                //chatRoom.ChatMessages.Add(chatMessage);
                List<ChatMessage> chatMessages = new List<ChatMessage>();

                temp = chatServer.SendMessage(chatRoom.RoomName, user.Name, fullPath, chatMessage);


                //  temp = chatMessages;
                PopulateMessages(temp);

                if (Window5.instance != null && Window5.instance.chatRoom.RoomName == chatRoom.RoomName)
                {
                    Window5.instance.PopulateMessages(temp);
                }
                if (Window3.instance != null && Window3.instance.chatRoom.RoomName == chatRoom.RoomName)
                {
                    Window3.instance.PopulateMessages(temp);
                }
                if (Window6.instance != null && Window6.instance.chatRoom.RoomName == chatRoom.RoomName)
                {
                    Window6.instance.PopulateMessages(temp);
                }
                if (Window8.instance != null && Window8.instance.chatRoom.RoomName == chatRoom.RoomName)
                {
                    Window8.instance.PopulateMessages(temp);
                }



            }
        }


        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(message))
            {





                ChatMessage chatMessage = new ChatMessage { User = user.Name, Message = message };


            

                temp = chatServer.SendMessage(chatRoom.RoomName, user.Name, message, chatMessage);



                if (Window5.instance != null && Window5.instance.chatRoom.RoomName == chatRoom.RoomName)
                {
                    Window5.instance.PopulateMessages(temp);
                }
                if (Window3.instance != null && Window3.instance.chatRoom.RoomName == chatRoom.RoomName)
                {
                    Window3.instance.PopulateMessages(temp);
                }
                if (Window6.instance != null && Window6.instance.chatRoom.RoomName == chatRoom.RoomName)
                {
                    Window6.instance.PopulateMessages(temp);
                }
                if (Window8.instance != null && Window8.instance.chatRoom.RoomName == chatRoom.RoomName)
                {
                    Window8.instance.PopulateMessages(temp);
                }




              //  lv1.ItemsSource = chatMessages;


                MessageTextBox.Clear();

                PopulateMessages(temp);
                PopulateUserListBox();

                /*foreach (var instance in instances)
                {
                    instance.lv1.Items.Refresh();
                }*/

            }


        }

        public void PopulateMessages(List<ChatMessage> inList)
        {
            ChatBox.Document = new FlowDocument();
            foreach (ChatMessage lis in inList)
            {

                var userName = lis.User + ": ";
                var message = lis.Message;

                // Check if the message is a URL

                if (File.Exists(message))
                {


                    // Create a clickable link for the shared file
                    var hyperlink = new Hyperlink(new Run($"[Shared file: {Path.GetFileName(message)}]"));

                    hyperlink.NavigateUri = new Uri(message); // Use a relative or absolute file path
                    hyperlink.MouseLeftButtonDown += (sender, e) =>
                    {
                        try
                        {
                            // Open the file using the default program
                            Process.Start(message);
                            e.Handled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error opening file: {ex.Message}");
                        }
                    };

                    Run run = new Run(userName);

                    Paragraph usernameParagraph = new Paragraph(run);
                    ChatBox.Document.Blocks.Add(usernameParagraph);
                    // Add the clickable link to a UI element (e.g., a StackPanel or TextBlock)

                    Paragraph fileParagraph = new Paragraph(hyperlink);


                    fileParagraph.MouseEnter += (sender, e) =>
                    {
                        // Change the background color when the mouse enters the paragraph
                        fileParagraph.Background = Brushes.LightGray;

                        Mouse.OverrideCursor = Cursors.Hand;
                    };

                    fileParagraph.MouseLeave += (sender, e) =>
                    {
                        // Restore the default background color when the mouse leaves the paragraph
                        fileParagraph.Background = Brushes.Transparent;
                        Mouse.OverrideCursor = null;
                    };
                    ChatBox.Document.Blocks.Add(fileParagraph);


                }
                else
                {
                    var messagerun = new Run(userName + "\n" + message);
                    Paragraph messageParagraph = new Paragraph(messagerun);
                    ChatBox.Document.Blocks.Add(messageParagraph);
                }



            }
        }

        private void LeaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Close this chat window
            chatServer.RemoveChatUsers(chatRoom.RoomName, user);

            // Show the previous window (Window2) if it's not null
            Window2 chatRoomSelectionWindow = new Window2(chatServer, user, countClass, 4);
            chatRoomSelectionWindow.Show();
            //Close();
            Hide();
        }

        public void PopulateUserListBox()
        {
            userBox.Document = new FlowDocument();
            userList = chatServer.GetChatRoomUsers(chatRoom);

            foreach (User user in userList)
            {

                var userName = user.Name;
                //  var message = lis.Message;

                // Check if the message is a URL

                Run run = new Run(userName);
                // Create a clickable link for the shared file
                var hyperlink = new Hyperlink(run);
                hyperlink.TextDecorations = null;

                hyperlink.MouseLeftButtonDown += (sender, e) =>
                {
                    try
                    {
                        // Open the file using the default program
                        selectedUser = user;

                        directMsgBut.Background = Brushes.LightBlue;
                        e.Handled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error setting user: {ex.Message}");
                    }
                };



                Paragraph usernameParagraph = new Paragraph(hyperlink);

                usernameParagraph.MouseEnter += (sender, e) =>
                {
                    // Change the background color when the mouse enters the paragraph
                    usernameParagraph.Background = Brushes.LightBlue;
                    Mouse.OverrideCursor = Cursors.Hand;
                };



                usernameParagraph.MouseLeave += (sender, e) =>
                {
                    // Restore the default background color when the mouse leaves the paragraph
                    usernameParagraph.Background = Brushes.Transparent;

                    Mouse.OverrideCursor = null;
                };
                userBox.Document.Blocks.Add(usernameParagraph);



            }
        }

        private void DirectMessageButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected user from the UserListBox
           // User selectedUser = UserListBox.SelectedItem as User;

            if (selectedUser != null)
            {
                // Open a private message window with the selected user

                if (Window5.instance != null && (Window5.instance.user.Name == selectedUser.Name))
                {
                    Window5.instance.DMButton4.Visibility = Visibility.Visible;
                    DMWindow dmWindow = new DMWindow(chatServer, user, Window5.instance.user);
                    MainWindow.ActiveDMWindows.Add(dmWindow);
                    dmWindow.Show();
                }
                else if (Window3.instance != null && (Window3.instance.user.Name == selectedUser.Name))
                {
                    Window3.instance.DMButton4.Visibility = Visibility.Visible;
                    DMWindow dmWindow = new DMWindow(chatServer, user, Window3.instance.user);
                    MainWindow.ActiveDMWindows.Add(dmWindow);
                    dmWindow.Show();
                }
                else if (Window6.instance != null && (Window6.instance.user.Name == selectedUser.Name))
                {
                    Window6.instance.DMButton4.Visibility = Visibility.Visible;
                    DMWindow dmWindow = new DMWindow(chatServer, user, Window6.instance.user);
                    MainWindow.ActiveDMWindows.Add(dmWindow);
                    dmWindow.Show();
                }
                else if (Window8.instance != null && (Window8.instance.user.Name == selectedUser.Name))
                {
                    Window8.instance.DMButton4.Visibility = Visibility.Visible;
                    DMWindow dmWindow = new DMWindow(chatServer, user, Window8.instance.user);
                    MainWindow.ActiveDMWindows.Add(dmWindow);
                    dmWindow.Show();
                }

                /*else if (Window6.instance != null)
                {
                    Window6.instance.lv1.ItemsSource = chatMessages;
                }
                else if (Window7.instance != null)
                {
                    Window7.instance.lv1.ItemsSource = chatMessages;
                }
                else if (Window8.instance != null)
                {
                    Window8.instance.lv1.ItemsSource = chatMessages;
                }*/


                OpenPrivateMessageWindow(selectedUser);
            }
            else
            {
                MessageBox.Show("Please select a user to initiate a private message.");
            }
        }

  
        private void OpenPrivateMessageWindow(User selectedUser)
        {
            // Create and open a private message window with the selected user
            //PrivateMessageWindow privateMessageWindow = new PrivateMessageWindow(selectedUser);
            //privateMessageWindow.Show();
        }

        private void DMButton2_Click(object sender, RoutedEventArgs e)
        {
            DMWindow dMWindowUser1 = new DMWindow(chatServer, user, Window5.instance.user);
            MainWindow.ActiveDMWindows.Add(dMWindowUser1);
            dMWindowUser1.Show();
        }

        private void DMButton_Click(object sender, RoutedEventArgs e)
        {
            DMWindow dMWindowUser1 = new DMWindow(chatServer, user, Window3.instance.user);
            MainWindow.ActiveDMWindows.Add(dMWindowUser1);
            dMWindowUser1.Show();
        }
        private void DMButton3_Click(object sender, RoutedEventArgs e)
        {
            DMWindow dMWindowUser1 = new DMWindow(chatServer, user, Window6.instance.user);
            MainWindow.ActiveDMWindows.Add(dMWindowUser1);
            dMWindowUser1.Show();
        }
        private void DMButton5_Click(object sender, RoutedEventArgs e)
        {
            DMWindow dMWindowUser1 = new DMWindow(chatServer, user, Window8.instance.user);
            MainWindow.ActiveDMWindows.Add(dMWindowUser1);
            dMWindowUser1.Show();
        }

        private void DMButton4_Click(object sender, RoutedEventArgs e)
        {

        }

        public void reloadUsers()
        {
            if (Window5.instance != null && Window5.instance.chatRoom.RoomName == chatRoom.RoomName)
            {
                Window5.instance.PopulateUserListBox();
            }
            if (Window3.instance != null && Window3.instance.chatRoom.RoomName == chatRoom.RoomName)
            {
                Window3.instance.PopulateUserListBox();
            }
            if (Window6.instance != null && Window6.instance.chatRoom.RoomName == chatRoom.RoomName)
            {
                Window6.instance.PopulateUserListBox();
            }
            if (Window8.instance != null && Window8.instance.chatRoom.RoomName == chatRoom.RoomName)
            {
                Window8.instance.PopulateUserListBox();
            }

        }
    }
}
