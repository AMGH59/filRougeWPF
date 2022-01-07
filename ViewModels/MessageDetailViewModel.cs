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
using System.Windows.Input;
using static devTalksWPF.Classes.Message;

namespace devTalksWPF.ViewModels
{
    public class MessageDetailViewModel : ViewModelBase
    {
        AdminHomeViewModel adminHomeViewModel;
        MessageDetailWindow _currentWindow;
        MessageRepository messageRepository;
        TopicRepository topicRepository;
        private Message message;
        private Topic topic;

        public MessageDetailViewModel(Message message, MessageDetailWindow currentWindow, AdminHomeViewModel aHVM)
        {
            adminHomeViewModel = aHVM;
            _currentWindow = currentWindow;
            topicRepository = new TopicRepository(new DataContext());
            messageRepository = new MessageRepository(new DataContext());

            Topics = new ObservableCollection<Topic>(topicRepository.GetAll().Where(t => t.Id == message.Id_topic));
            Topic = Topics.FirstOrDefault(t => t.Id == message.Id_topic);
            DetailMessage = new ObservableCollection<Message>(messageRepository.GetAll().Where(t => t.Id == message.Id));
            Body = message.Body;
            User = message.User;
            SelectedMessage = message;

            AcceptCommand = new RelayCommand(AcceptAction);
            ReportCommand = new RelayCommand(ReportAction);
            DeleteCommand = new RelayCommand(DeleteAction);
        }

        public Message Message { get; set; }
        public Message SelectedMessage { get; set; }
        public Topic Topic { get; set; }
        public ObservableCollection<Message> DetailMessage { get; set; }
        public ObservableCollection<Topic> Topics { get; set; }
        public User User { get; set; }
        public string Body { get; set; }
        public ICommand AcceptCommand { get; set; }
        public ICommand ReportCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public void AcceptAction()
        {
            UpdateMessage(Message.StateMessageEnum.Accept);
        }
        public void ReportAction()
        {
            UpdateMessage(Message.StateMessageEnum.Reported);
        }
        public void DeleteAction()
        {
            UpdateMessage(Message.StateMessageEnum.Disallow);
        }
        public void UpdateMessage(Message.StateMessageEnum stateMessageEnum)
        {
            if (SelectedMessage != null)
            {
                SelectedMessage.StateMessage = stateMessageEnum;
            }
            Task.Run(() =>
            {
                if (messageRepository.Update(SelectedMessage))
                {
                    Message TempMessage = SelectedMessage;
                    _currentWindow.Dispatcher.Invoke(() =>
                    {
                        int i = DetailMessage.IndexOf(SelectedMessage);
                        DetailMessage.Remove(SelectedMessage);
                        DetailMessage.Insert(i, TempMessage);
                        adminHomeViewModel.ReportedMessage = new ObservableCollection<Message>(messageRepository.Search(m => m.StateMessage == Message.StateMessage));
                        adminHomeViewModel.RaisePropertyChanged("ReportedMessage");
                    });
                }
            });
        }
    }
}
