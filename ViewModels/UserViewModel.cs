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
            BanCommand = new RelayCommand(BanAction);
            RestoreCommand = new RelayCommand(RestoreAction);
            AdminCommand = new RelayCommand(AdminAction);
            StartDate = DateTime.Parse("01-01-2020");
            EndDate = DateTime.Now.AddDays(1);
            FirstName = "";
            LastName = "";
        }
        public void BanAction()
        {
            UpdateUser(User.StateEnum.Ban);
        }
        public void RestoreAction()
        {
            UpdateUser(User.StateEnum.Accept);
        }
        public void AdminAction()
        {
            if (SelectedUser != null)
            {
                SelectedUser.IsAdmin = true;
            }
            Task.Run(() =>
            {
                if (_userRepository.Update(SelectedUser))
                {
                    User TempUser = SelectedUser;
                    _currentWindow.Dispatcher.Invoke(() =>
                    {
                        RaisePropertyChanged("Users");
                    });
                }
            });
        }
        private void UpdateUser(User.StateEnum stateEnum)
        {
            if (SelectedUser != null)
            {
                SelectedUser.StateUser = stateEnum;
            }
            Task.Run(() =>
            {
                if (_userRepository.Update(SelectedUser))
                {
                    User TempUser = SelectedUser;
                    _currentWindow.Dispatcher.Invoke(() =>
                    {
                        int i = Users.IndexOf(SelectedUser);
                        Users.Remove(TempUser);
                        Users.Insert(i, TempUser);
                        _ahvm.ReportedUsers = new ObservableCollection<User>(_userRepository.Search(u => u.StateUser == User.StateEnum.Waiting));
                    });
                }
            });
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
        public ICommand BanCommand { get; set; }
        public ICommand RestoreCommand { get; set; }
        public ICommand AdminCommand { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User SelectedUser { get; set; }

    }
}