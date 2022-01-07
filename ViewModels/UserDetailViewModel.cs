using devTalksWPF.Classes;
using devTalksWPF.Repositories;
using devTalksWPF.Views;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.ViewModels
{
    public class UserDetailViewModel : ViewModelBase
    {
        UserDetailWindow _currentWindow;
        UserRepository userRepository;
        TopicRepository topicRepository;
        MessageRepository messageRepository;
        public UserDetailViewModel(User user, UserDetailWindow currentWindow)
        {
            _currentWindow = currentWindow;
            userRepository = new UserRepository(new DataContext());
            topicRepository = new TopicRepository(new DataContext());
            messageRepository = new MessageRepository(new DataContext());
            DetailUser = new ObservableCollection<User>(userRepository.GetAll().Where(u => u.Id == user.Id));
            DetailUserTopic = new ObservableCollection<Topic>(topicRepository.GetAll().Where(t => t.AuthorId == user.Id));
            DetailUserMessage = new ObservableCollection<Message>(messageRepository.GetAll().Where(m => m.User.Id == user.Id));
        }

        public ObservableCollection<User> DetailUser { get; set; }
        public ObservableCollection<Topic> DetailUserTopic { get; set; }
        public ObservableCollection<Message> DetailUserMessage { get; set; }
    }
}
