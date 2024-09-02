using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatDataTier
{
    public class ChatRoom : INotifyPropertyChanged
    {
        public string RoomName { get; set; }


        public List<User> Participants  = new List<User>();

        public void addUser(User user) 
        { 
            Participants.Add(user);
        }

        public List<User> getUsers()
        {
            return Participants;
        }


        private List<string> messageHistory = new List<string>();

        public List<string> MessageHistory
        {
            get { return messageHistory; }
            set
            {
                messageHistory = value;
                OnPropertyChanged(nameof(MessageHistory));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<PrivateMessage> PrivateMessages { get; } = new List<PrivateMessage>();

        public ObservableCollection<ChatMessage> ChatMessages = new ObservableCollection<ChatMessage>();


    }

   
}
