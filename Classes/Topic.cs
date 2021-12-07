using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Classes
{
    class Topic
    {
        private int id;
        private string question;
        private string body;
        private List<Message> responses;
        private List<Techno> technos;
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
        public List<Techno> Technos { get => technos; set => technos = value; }
        internal List<Message> Responses { get => responses; set => responses = value; }
    }
}
