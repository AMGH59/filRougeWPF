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
    public class UserViewModel : ViewModelBase
    {
        private AdminHomeViewModel _ahvm;
        private UserRepository _userRepository;
        private UserWindow _currentWindow;
        public UserViewModel(AdminHomeViewModel ahvm,UserWindow currentWindow)
        {
            _ahvm = ahvm;
            _userRepository = new UserRepository(new DataContext());
            _currentWindow = currentWindow;
            Users = new ObservableCollection<User>(_userRepository.GetAll());
            SearchCommand = new RelayCommand(SearchAction);
            StartDate = DateTime.Parse("01-01-2020");
            EndDate = DateTime.Now.AddDays(1);
            FirstName = "";
            LastName = "";
        }
        public void SearchAction()
        {
            Task.Run(() =>
            {
                if (Int32.TryParse(UserId, out int UserIdInt))
                {
                    Users = new ObservableCollection<User>(_userRepository.Search(u => u.Id == UserIdInt && u.RegistrationDate >= StartDate && u.RegistrationDate <= EndDate &&
                    u.FirstName.Contains(FirstName) && u.LastName.Contains(LastName)));
                }
                else
                {
                    Users = new ObservableCollection<User>(_userRepository.Search(u => u.RegistrationDate >= StartDate && u.RegistrationDate <= EndDate &&
                    u.FirstName.Contains(FirstName) && u.LastName.Contains(LastName)));
                }
                _currentWindow.Dispatcher.Invoke(() =>
                {
                    RaisePropertyChanged("Users");
                });
            });
        }
        public ObservableCollection<User> Users { get; set; }
        public ICommand SearchCommand { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}