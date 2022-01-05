using devTalksWPF.Classes;
using devTalksWPF.Repositories;
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
    class TopicsViewModel : ViewModelBase
    {
        TopicRepository topicRepository;
        public TopicsViewModel()
        {
            topicRepository = new TopicRepository(new DataContext());
            Topics = new ObservableCollection<Topic>(topicRepository.GetAll());
            //SearchCommand = new RelayCommand(SearchAction);
        }

        //public void SearchAction()
        //{
        //    Topics= new ObservableCollection<Topic>(topicRepository.Search(t=> t.Id==TopicId));
        //}

        public ObservableCollection<Topic> Topics { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User Author { get; set; }
        public int TopicId { get; set; }
        public string KeyWord { get; set; }
        public ICommand SearchCommand { get; set; }


    }
}
