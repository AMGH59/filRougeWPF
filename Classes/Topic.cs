using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devTalksWPF.Classes
{
    public class Topic
    {
        private int id;
        private string question;
        private string body;
        //private List<Message> responses;
        //private List<Techno> technos;
        private DateTime date;
        public int AuthorId { get; set; }

        public enum StateEnum
        {
            Disallow,
            InProgress,
            Resolved
        }

        public Topic()
        {
            Date = DateTime.Now;
            StateTopic = StateEnum.InProgress;
        }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public int Id { get => id; set => id = value; }
        public string Question { get => question; set => question = value; }
        public string Body { get => body; set => body = value; }
        public virtual List<Message> Responses { get; set; }
        public virtual List<Techno> Technos { get ; set; }
        public StateEnum StateTopic { get; set; }
        public DateTime Date { get => date; set => date = value; }
    }
}
