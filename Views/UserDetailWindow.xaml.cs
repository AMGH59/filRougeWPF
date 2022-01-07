using devTalksWPF.Classes;
using devTalksWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace devTalksWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour UserDetailWindow.xaml
    /// </summary>
    public partial class UserDetailWindow : Window
    {
        public UserDetailWindow(User user, AdminHomeViewModel ahvm)
        {
            InitializeComponent();
            DataContext = new UserDetailViewModel(user, this, ahvm);
        }
    }
}
