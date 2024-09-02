using ChatDataTier;
using ChatServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
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
    /// Interaction logic for DMWindow.xaml
    /// </summary>
    public partial class DMWindow : Window
    {
        private DataserverInterface chatServer;
        private User user1;
        private User user2;
        public static DMWindow instance;
        public List<ChatMessage> DMchatMessages = new List<ChatMessage>();
        public DMWindow(DataserverInterface chatServer1,User user11,User user22)
        {
            InitializeComponent();
            ChannelFactory<DataserverInterface> foobFactory;
            NetTcpBinding tcp = new NetTcpBinding();
            string URL = "net.tcp://localhost:8100/DataService";
            foobFactory = new ChannelFactory<DataserverInterface>(tcp, URL);
            chatServer = chatServer1;
            user1 = user11;
            user2 = user22;

            PopulateChatListBox();
        }

        public void PopulateChatListBox()
        {
            DMChatBox.Document = new FlowDocument();
            DMchatMessages = chatServer.GetPrivateChatInstance(user1.Name, user2.Name, null);

            foreach (ChatMessage Lismessage in DMchatMessages)
            {
                var userName = Lismessage.User + ": ";
                var message = Lismessage.Message;
                //  var message = lis.Message;

                // Check if the message is a URL


                var messagerun = new Run(userName + ":\n" + message);
                Paragraph messageParagraph = new Paragraph(messagerun);
                DMChatBox.Document.Blocks.Add(messageParagraph);


            }
        }

        private void DMSendButton_Click(object sender, RoutedEventArgs e)
        {
            
            string message = DMMessageTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(message))
            {

                
                
                //ChatMessage chatMessage = new ChatMessage { User = "You", Message = message };
              chatServer.GetPrivateChatInstance(user1.Name, user2.Name, message);
                PopulateChatListBox();


                DMMessageTextBox.Clear();

                if (Window5.instance != null && Window5.instance.user.Name == user2.Name)
                {
                    
                }

                foreach (var dmWindow in MainWindow.ActiveDMWindows)
                {
                    dmWindow.PopulateChatListBox();
                }

            }
        }

   

        private void DMCloseButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.ActiveDMWindows.Remove(this);
            this.Close();
            
        }
    }
}

