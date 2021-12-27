using devTalksWPF.Classes;
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

namespace devTalksWPF.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        private string email,erreur;
        private Admin admin;
        LoginWindow currentLoginWindow;

        public LoginViewModel(LoginWindow currentLoginWindow)
        {
            LoginCommand = new RelayCommand(Login);
            CurrentLoginWindow = currentLoginWindow;
        }

        public void Login()
        {
            if (Password == "admin")
            {
                admin = new Admin();
                AdminHomeWindow AdminWindow = new AdminHomeWindow();
                AdminWindow.Show();
                CurrentLoginWindow.Close();
            }else
            {
                Erreur = "E-mail ou mot de passe incorrect.";
                RaisePropertyChanged("Erreur");
            }

        }

        public ICommand LoginCommand { get; set; }
        public string Password { private get; set; }
        internal Admin Admin { get => admin; set => admin = value; }
        public LoginWindow CurrentLoginWindow { get => currentLoginWindow; set => currentLoginWindow = value; }
        public string Email { get => email; set => email = value; }
        public string Erreur { get => erreur; set => erreur = value; }
    }
}
