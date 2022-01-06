using devTalksWPF.Classes;
using devTalksWPF.Repositories;
using devTalksWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.ViewModels
{
    public class MessageViewModel
    {
        MessageRepository messageRepository;
        MessageWindow _currentWindow;
        public MessageViewModel(MessageWindow currentWindow)
        {
            _currentWindow = currentWindow;
            messageRepository = new MessageRepository(new DataContext());
            Messages = new ObservableCollection<Message>(messageRepository.GetAll());
        }

        public ObservableCollection<Message> Messages { get; set; }
        public string Id { get; set; }
        public string User { get; set; }

    }
}
