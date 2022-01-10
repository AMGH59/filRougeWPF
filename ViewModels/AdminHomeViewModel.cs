using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using devTalksWPF.Classes;
using devTalksWPF.Repositories;
using devTalksWPF.Tools;
using devTalksWPF.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace devTalksWPF.ViewModels
{
    public class AdminHomeViewModel : ViewModelBase
    {
        //private User user;
        //private Topic topic;
        //private Forum forum;
        UserRepository userRepository;
        MessageRepository messageRepository;
        public AdminHomeViewModel(User loggedAdmin)
        {
            TopicWindowCommand = new RelayCommand(OpenTopic);
            MessageWindowCommand = new RelayCommand(OpenMessage);
            UserWindowCommand = new RelayCommand(OpenUser);
            userRepository = new UserRepository(new DataContext());
            ReportedUsers = new ObservableCollection<User>(userRepository.Search(u => u.StateUser == User.StateEnum.Waiting));
            BanCommand = new RelayCommand(ActionBanUser);
            DontBanCommand = new RelayCommand(ActionDontBanUser);
            AcceptMessageCommand = new RelayCommand(ActionAcceptMessage);
            DisallowMessageCommand = new RelayCommand(ActionDisallowMessage);
            CloseAppCommand = new RelayCommand(ActionCloseApp);
            AccessUserReportedCommand = new RelayCommand(AccessUserAction);
            AccessMessageReportedCommand = new RelayCommand(AccessMessageAction);
            messageRepository = new MessageRepository(new DataContext());
            ReportedMessage = new ObservableCollection<Message>(messageRepository.Search(m => m.StateMessage == Message.StateMessageEnum.Reported));
            LoggedAdmin = loggedAdmin;
        }

        public void ActionCloseApp()
        {
            LoginWindow lw = new LoginWindow();
            lw.Show();
            foreach (Window w in App.Current.Windows)
                if(w!=lw)
                    w.Close();
        }

        public void ActionAcceptMessage()
        {
            if (SelectedMessage != null)
            {
                SelectedMessage.StateMessage = Message.StateMessageEnum.Accept;
                Task.Run(() => {
                    if (messageRepository.Update(SelectedMessage))
                    {

                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            ReportedMessage.Remove(SelectedMessage);
                        });
                    }
                });
            }
        }
        public void ActionDisallowMessage()
        {
            if (SelectedMessage != null)
            {
                SelectedMessage.StateMessage = Message.StateMessageEnum.Disallow;
                Task.Run(() => {
                    if (messageRepository.Update(SelectedMessage))
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            ReportedMessage.Remove(SelectedMessage);
                        });

                    }
                });
            }
        }

        public void ActionBanUser()
        {
            if (SelectedUser != null)
            {
                SelectedUser.StateUser = User.StateEnum.Ban;
                Task.Run(()=> {
                    if (userRepository.Update(SelectedUser))
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            ReportedUsers.Remove(SelectedUser);
                        });

                    }
                });
            }
        }
        public void ActionDontBanUser()
        {
            if (SelectedUser != null)
            {
                SelectedUser.StateUser = User.StateEnum.Accept;
                Task.Run(() => {
                    if (userRepository.Update(SelectedUser))
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            ReportedUsers.Remove(SelectedUser);
                        });

                    }
                });
            }
        }

        public void OpenTopic()
        {
            TopicWindow tWindow = new TopicWindow();
            tWindow.Show();
        }
        public void OpenMessage()
        {
            MessageWindow mWindow = new MessageWindow(this);
            mWindow.Show();
        }
        public void OpenUser()
        {
            UserWindow uWindow = new UserWindow(this);
            uWindow.Show();
        }

        public void AccessMessageAction()
        {
            if (SelectedMessage != null)
            {
                MessageDetailWindow mDW = new MessageDetailWindow(SelectedMessage, this);
                AccessAction(mDW);
            }
        }
        public void AccessUserAction()
        {
            if (SelectedUser != null)
            {
                UserDetailWindow uDW = new UserDetailWindow(SelectedUser, this);
                AccessAction(uDW);
            }
        }
        public void AccessAction(Window window)
        {
            window.Show();
        }

        public ObservableCollection<User> ReportedUsers { get; set; }
        public ObservableCollection<Message> ReportedMessage { get; set; }
        public User LoggedAdmin { get; set; }
        public User SelectedUser { get; set; }
        public Message SelectedMessage { get; set; }
        public string WelcomeMessage { get; set; }
        public string Body { get; set; }
        public ICommand BanCommand { get; set; }
        public ICommand DontBanCommand { get; set; }
        public ICommand TopicWindowCommand { get; set; }
        public ICommand MessageWindowCommand { get; set; }
        public ICommand UserWindowCommand { get; set; }
        public ICommand DisallowMessageCommand { get; set; }
        public ICommand AcceptMessageCommand { get; set; }
        public ICommand CloseAppCommand { get; set; }
        public ICommand AccessUserReportedCommand { get; set; }
        public ICommand AccessMessageReportedCommand { get; set; }
    }
}
