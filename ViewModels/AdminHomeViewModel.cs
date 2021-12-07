﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using devTalksWPF.Classes;
using devTalksWPF.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace devTalksWPF.ViewModels
{
    class AdminHomeViewModel : ViewModelBase
    {
        //private User user;
        //private Topic topic;
        //private Forum forum;

        public AdminHomeViewModel()
        {
            TopicWindowCommand = new RelayCommand(OpenTopic);
            MessageWindowCommand = new RelayCommand(OpenMessage);
        }


        public ICommand TopicWindowCommand { get; set; }
        public ICommand MessageWindowCommand { get; set; }


        public void OpenTopic()
        {
            TopicWindow tWindow = new TopicWindow();
            tWindow.Show();
        }
        public void OpenMessage()
        {
            MessageWindow mWindow = new MessageWindow();
            mWindow.Show();
        }

}
}
