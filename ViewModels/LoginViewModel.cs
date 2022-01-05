using devTalksWPF.Classes;
using devTalksWPF.Repositories;
using devTalksWPF.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Threading;


namespace devTalksWPF.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        private string email,erreur;
        private Admin admin;
        LoginWindow currentLoginWindow;
        UserRepository userRepository;

        public LoginViewModel(LoginWindow currentLoginWindow)
        {
            userRepository = new UserRepository(new DataContext());
            LoginCommand = new RelayCommand(Login);
            CurrentLoginWindow = currentLoginWindow;
        }

        public void Login()
        {
            User user = default(User);
            Task.Run(() =>
            {
                user = userRepository.SearchOne(u => u.Password == Password && u.Email == Email && u.IsAdmin);
                CurrentLoginWindow.Dispatcher.Invoke(() =>
                {
                    if (user != default(User))
                    {
                        admin = new Admin();
                        AdminHomeWindow AdminWindow = new AdminHomeWindow();
                        AdminWindow.Show();
                        CurrentLoginWindow.Close();
                    }
                    else
                    {
                        Erreur = "E-mail ou mot de passe incorrect.";
                        RaisePropertyChanged("Erreur");
                    }
                });

            });

        }

        public ICommand LoginCommand { get; set; }
        public string Password { private get; set; }
        internal Admin Admin { get => admin; set => admin = value; }
        public LoginWindow CurrentLoginWindow { get => currentLoginWindow; set => currentLoginWindow = value; }
        public string Email { get => email; set => email = value; }
        public string Erreur { get => erreur; set => erreur = value; }
    }
}
