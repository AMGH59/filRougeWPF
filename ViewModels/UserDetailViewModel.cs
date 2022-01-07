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
        AdminHomeViewModel adminHomeViewModel;
        UserDetailWindow _currentWindow;
        UserRepository userRepository;
        TopicRepository topicRepository;
        MessageRepository messageRepository;
        public UserDetailViewModel(User user, UserDetailWindow currentWindow, AdminHomeViewModel aHVM)
        {
            adminHomeViewModel = aHVM;
            _currentWindow = currentWindow;
            userRepository = new UserRepository(new DataContext());
            topicRepository = new TopicRepository(new DataContext());
            messageRepository = new MessageRepository(new DataContext());
            DetailUser = new ObservableCollection<User>(userRepository.GetAll().Where(u => u.Id == user.Id));
            DetailUserTopic = new ObservableCollection<Topic>(topicRepository.GetAll().Where(t => t.AuthorId == user.Id));
            DetailUserMessage = new ObservableCollection<Message>(messageRepository.GetAll().Where(m => m.User.Id == user.Id));

            AccessTopicCommand = new RelayCommand(AccessTopicAction);
            AccessMessageCommand = new RelayCommand(AccessMessageAction);
            BanCommand = new RelayCommand(BanAction);
            RestoreCommand = new RelayCommand(RestoreAction);
        }

        public ObservableCollection<User> DetailUser { get; set; }
        public ObservableCollection<Topic> DetailUserTopic { get; set; }
        public ObservableCollection<Message> DetailUserMessage { get; set; }
        public ICommand AccessTopicCommand { get; set; }
        public ICommand AccessMessageCommand { get; set; }
        public ICommand BanCommand { get; set; }
        public ICommand RestoreCommand { get; set; }
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
                MessageDetailWindow mDW = new MessageDetailWindow(SelectedUserMessage, adminHomeViewModel);
                AccessAction(mDW);
            }
        }
        public void AccessAction(Window window)
        {
            window.Show();
        }


        public void BanAction()
        {
            UpdateUser(User.StateEnum.Ban);
        }
        public void RestoreAction()
        {
            UpdateUser(User.StateEnum.Accept);
        }
        private void UpdateUser(User.StateEnum stateEnum)
        {
            if (SelectedUser != null)
            {
                SelectedUser.StateUser = stateEnum;
            }
            Task.Run(() =>
            {
                if (userRepository.Update(SelectedUser))
                {
                    User TempUser = SelectedUser;
                    _currentWindow.Dispatcher.Invoke(() =>
                    {
                        int i = DetailUser.IndexOf(SelectedUser);
                        DetailUser.Remove(TempUser);
                        DetailUser.Insert(i, TempUser);
                        adminHomeViewModel.ReportedUsers = new ObservableCollection<User>(userRepository.Search(u => u.StateUser == User.StateEnum.Waiting));
                        adminHomeViewModel.RaisePropertyChanged("ReportedUsers");
                    });
                }
            });
        }
    }
}
