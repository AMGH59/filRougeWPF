using devTalksWPF.Classes;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace devTalksWPF.ViewModels
{
    public class TopicDetailViewModel : ViewModelBase
    {
        private Topic topic;
        public TopicDetailViewModel(Topic topic)
        {
            Topic = topic;
            Publisher = $"de {Topic.Author.FirstName} {Topic.Author.LastName} le {Topic.Date}";
            Reponses = TextResponse();
            ResponseTitle = Topic.Responses.Count() > 1 ? "Réponses :" : "Réponse :";
        }

        private string TextResponse()
        {
            string reponses="";
            if (Topic.Responses.Count() != 0)
            {
                foreach (Message m in Topic.Responses)
                {
                    reponses += $"Message n°{m.Id} posté par {m.User.FirstName} {m.User.LastName} (Id n°{m.User.Id}) le {m.Date} : \n\n {m.Body}\n\n\n";
                }
                return reponses;
            }
            return "Il n'y pas encore de réponse pour ce topic.";
        }
        public string ResponseTitle { get; set; }
        public string Reponses { get; set; }
        public Topic Topic { get ; set; }
        public string Publisher { get; set; }
    }
}