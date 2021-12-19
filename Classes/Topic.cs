using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Classes
{
    public class Topic
    {
        private int id;
        private string question;
        private string body;

        private enum State
        {
            Desallow,
            InProgress,
            Resolved
        }

        public Topic()
        {

        }

        public int Id { get => id; set => id = value; }
        public string Question { get => question; set => question = value; }
        public string Body { get => body; set => body = value; }
        public virtual List<Message> Responses { get; set; }
        public virtual List<Techno> Technos { get; set; }
    }
}
