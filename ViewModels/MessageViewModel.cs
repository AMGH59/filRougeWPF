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

namespace devTalksWPF.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
        MessageRepository messageRepository;
        MessageWindow _currentWindow;
        public MessageViewModel(MessageWindow currentWindow)
        {
            _currentWindow = currentWindow;
            messageRepository = new MessageRepository(new DataContext());
            Messages = new ObservableCollection<Message>(messageRepository.GetAll());
            StartDate = DateTime.Parse("01-01-2020");
            EndDate = DateTime.Now.AddDays(30);
            Author = "";
            KeyWord = "";

            SearchCommand = new RelayCommand(SearchAction);
            DeleteCommand = new RelayCommand(DeleteAction);
        }

        public ObservableCollection<Message> Messages { get; set; }
        public string MessageId { get; set; }
        public string User { get; set; }
        public string Author { get; set; }
        public string KeyWord { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public Message SelectedMessage { get; set; }


        public void SearchAction()
        {
            Task.Run(() =>
            {
                if (Int32.TryParse(MessageId, out int messageIdInt))
                {
                    Messages = new ObservableCollection<Message>(messageRepository.Search(m => m.Id == messageIdInt && m.Date >= StartDate && m.Date <= EndDate &&
                    (m.Topic.Author.FirstName.Contains(Author) || m.Topic.Author.LastName.Contains(Author) || m.Topic.Author.Email.Contains(Author)) && m.Body.Contains(KeyWord)));
                }
                else
                {
                    Messages = new ObservableCollection<Message>(messageRepository.Search(m => m.Date >= StartDate && m.Date <= EndDate &&
                    (m.Topic.Author.FirstName.Contains(Author) || m.Topic.Author.LastName.Contains(Author) || m.Topic.Author.Email.Contains(Author)) && m.Body.Contains(KeyWord)));
                }
                _currentWindow.Dispatcher.Invoke(() =>
                {
                    RaisePropertyChanged("Messages");
                });
            });
        }
        public void DeleteAction()
        {
            UpdateTopic(Message.StateMessageEnum.Disallow);
        }
        public void UpdateTopic(Message.StateMessageEnum stateMessageEnum)
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
                        int i = Messages.IndexOf(SelectedMessage);
                        Messages.Remove(SelectedMessage);
                        Messages.Insert(i, TempMessage);
                    });
                }
            });
        }

    }
}
