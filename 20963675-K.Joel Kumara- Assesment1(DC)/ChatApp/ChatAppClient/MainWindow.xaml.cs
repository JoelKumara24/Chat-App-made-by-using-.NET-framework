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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using ChatServer;
using ChatDataTier;


namespace ChatAppClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataserverInterface chatServer;
        private CountClass countClass = new CountClass();
        public static List<DMWindow> ActiveDMWindows = new List<DMWindow>();
        public MainWindow()
        {
            InitializeComponent();

            
            ChannelFactory<DataserverInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();
            string URL = "net.tcp://localhost:8100/DataService";
            foobFactory = new ChannelFactory<DataserverInterface>(tcp, URL);
            chatServer = foobFactory.CreateChannel();
            chatServer.CreateChatRoom("Initial ChatRoom");
            countClass.Count = 0;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(username))
            {
                try
                {
                    // Call the server's Login method
                    bool loginResult = chatServer.Login(username);

                    if (loginResult)
                    {
                        countClass.Count++;
                        User user = new User{ Name=username };
                         
                       Window2 chatRoomSelectionWindow = new Window2(chatServer,user,countClass,0);
                        chatRoomSelectionWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Username is already in use. Choose a different one.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }


    }
}
