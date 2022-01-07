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
    public class MessageDetailViewModel : ViewModelBase
    {
        MessageRepository messageRepository;
        TopicRepository topicRepository;
        private Message message;
        private Topic topic;

        public MessageDetailViewModel(Message message)
        {
            topicRepository = new TopicRepository(new DataContext());
            Topics = new ObservableCollection<Topic>(topicRepository.GetAll().Where(t => t.Id == message.Id_topic));
            Topic = Topics.FirstOrDefault(t => t.Id == message.Id_topic);
            DetailMessage = new ObservableCollection<Message>() { message };
            Body = message.Body;
            User = message.User;
        }

        public Message Message { get; set; }
        public Topic Topic { get; set; }
        public ObservableCollection<Message> DetailMessage { get; set; }
        public ObservableCollection<Topic> Topics { get; set; }
        public User User { get; set; }
        public string Body { get; set; }
    }
}
