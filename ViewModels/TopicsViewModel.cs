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
    public class TopicsViewModel : ViewModelBase
    {
        TopicRepository topicRepository;
        TopicWindow _currentWindow;
        public TopicsViewModel(TopicWindow currentWindow)
        {
            topicRepository = new TopicRepository(new DataContext());
            Topics = new ObservableCollection<Topic>(topicRepository.GetAll());
            SearchCommand = new RelayCommand(SearchAction);
            OpenCommand = new RelayCommand(OpenAction);
            _currentWindow = currentWindow;
            DeletedCommand = new RelayCommand(DeletedAction);
            ResolvedCommand = new RelayCommand(ResolvedAction);
            StartDate = DateTime.Parse("01-01-2020");
            EndDate = DateTime.Now.AddDays(30);
            Author = "";
            KeyWord = "";
        }

        public void OpenAction()
        {
            if (SelectedTopic != null)
            {
                SelectedTopic.StateTopic = Topic.StateEnum.InProgress;
            }
            Task.Run(() =>
            {
                if (topicRepository.Update(SelectedTopic))
                {
                    _currentWindow.Dispatcher.Invoke(() =>
                    {
                        SearchAction();
                    });
                }
            });
        }
        public void DeletedAction()
        {
            if (SelectedTopic != null)
            {
                SelectedTopic.StateTopic = Topic.StateEnum.Disallow;
            }
            Task.Run(() =>
            {
                if (topicRepository.Update(SelectedTopic))
                {
                    _currentWindow.Dispatcher.Invoke(() =>
                    {
                        SearchAction();
                    });
                }
            });
        }
        public void ResolvedAction()
        {
            if (SelectedTopic != null)
            {
                SelectedTopic.StateTopic = Topic.StateEnum.Resolved;
            }
            Task.Run(() =>
            {
                if (topicRepository.Update(SelectedTopic))
                {
                    _currentWindow.Dispatcher.Invoke(() =>
                    {
                        SearchAction();
                    });
                }
            });
        }

        public void SearchAction()
        {
            if(Int32.TryParse(TopicId,out int TopicIdInt))
            {
                Topics = new ObservableCollection<Topic>(topicRepository.Search(t => t.Id == TopicIdInt && t.Date >= StartDate && t.Date <= EndDate && 
                (t.Author.FirstName.Contains(Author) || t.Author.LastName.Contains(Author)) && t.Body.Contains(KeyWord)));
            }
            else
            {
                Topics = new ObservableCollection<Topic>(topicRepository.Search(t =>t.Date >= StartDate && t.Date <= EndDate &&
                (t.Author.FirstName.Contains(Author) || t.Author.LastName.Contains(Author)) && t.Body.Contains(KeyWord)));
            }
            RaisePropertyChanged("Topics");

        }

        public ObservableCollection<Topic> Topics { get; set; }
        public Topic SelectedTopic { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Author { get; set; }
        public string TopicId { get; set; }
        public string KeyWord { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand ResolvedCommand { get; set; }
        public ICommand DeletedCommand { get; set; }


    }
}
