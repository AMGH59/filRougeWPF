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
            TopicDetailCommand = new RelayCommand(TopicDetailAction);
            StartDate = DateTime.Parse("01-01-2020");
            EndDate = DateTime.Now.AddDays(1);
            AuthorSearch = "";
            KeyWord = "";
        }
        public void TopicDetailAction()
        {
            if (SelectedTopic != null)
            {
                TopicDetailWindow tdw = new TopicDetailWindow(SelectedTopic);
                tdw.Show();
            }
        }

        public void OpenAction()
        {
            UpdateTopic(Topic.StateEnum.InProgress);
        }
        public void DeletedAction()
        {
            UpdateTopic(Topic.StateEnum.Disallow);
        }
        public void ResolvedAction()
        {
            UpdateTopic(Topic.StateEnum.Resolved);
        }
        public void UpdateTopic(Topic.StateEnum stateEnum)
        {
            if (SelectedTopic != null)
            {
                SelectedTopic.StateTopic = stateEnum;
            }
            Task.Run(() =>
            {
                if (topicRepository.Update(SelectedTopic))
                {
                    Topic TempTopic = SelectedTopic;
                    _currentWindow.Dispatcher.Invoke(() =>
                    {
                        int i = Topics.IndexOf(SelectedTopic);
                        Topics.Remove(SelectedTopic);
                        Topics.Insert(i, TempTopic);
                    });
                }
            });
        }

        public void SearchAction()
        {
            Task.Run(() =>
            {
                if (Int32.TryParse(TopicId, out int TopicIdInt))
                {
                    Topics = new ObservableCollection<Topic>(topicRepository.Search(t => t.Id == TopicIdInt && t.Date >= StartDate && t.Date <= EndDate &&
                    (t.Author.FirstName.Contains(AuthorSearch) || t.Author.LastName.Contains(AuthorSearch)) && t.Body.Contains(KeyWord)));
                }
                else
                {
                    Topics = new ObservableCollection<Topic>(topicRepository.Search(t => t.Date >= StartDate && t.Date <= EndDate &&
                    (t.Author.FirstName.Contains(AuthorSearch) || t.Author.LastName.Contains(AuthorSearch)) && t.Body.Contains(KeyWord)));
                }
                _currentWindow.Dispatcher.Invoke(() =>
                {
                    RaisePropertyChanged("Topics");
                });
            });
        }

        public ObservableCollection<Topic> Topics { get; set; }
        public Topic SelectedTopic { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User Author { get; set; }
        public string AuthorSearch { get; set; }
        public string TopicId { get; set; }
        public string KeyWord { get; set; }
        public string StateTopics { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand OpenCommand { get; set; }
        public ICommand ResolvedCommand { get; set; }
        public ICommand DeletedCommand { get; set; }
        public ICommand TopicDetailCommand { get; set; }

    }
}
