using devTalksWPF.Classes;
using devTalksWPF.Repositories;
using devTalksWPF.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

            AccessTopicCommand = new RelayCommand(AccessTopicAction);
            AccessMessageCommand = new RelayCommand(AccessMessageAction);
        }

        public ObservableCollection<User> DetailUser { get; set; }
        public ObservableCollection<Topic> DetailUserTopic { get; set; }
        public ObservableCollection<Message> DetailUserMessage { get; set; }
        public ICommand AccessTopicCommand { get; set; }
        public ICommand AccessMessageCommand { get; set; }
        public User SelectedUser { get; set; }
        public Topic SelectedUserTopic { get; set; }
        public Message SelectedUserMessage { get; set; }

        public void AccessTopicAction()
        {
            if (SelectedUserTopic != null)
            {
                TopicDetailWindow tDW = new TopicDetailWindow(SelectedUserTopic);
                AccessAction(tDW);
            }
        }
        public void AccessMessageAction()
        {
            if (SelectedUserMessage != null)
            {
                MessageDetailWindow mDW = new MessageDetailWindow(SelectedUserMessage);
                AccessAction(mDW);
            }
        }
        public void AccessAction(Window window)
        {
            window.Show();
        }
    }
}
