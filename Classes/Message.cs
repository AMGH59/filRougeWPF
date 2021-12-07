using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Classes
{
    class Message
    {
        private int id;
        private int id_topic;
        private int id_user;
        private string body;
        private DateTime date;
        private enum State
        {
            Reported,
            Accept,
            Disallow
        }
        public Message()
        {

        }
        public int Id { get => id; set => id = value; }
        public int Id_topic { get => id_topic; set => id_topic = value; }
        public int Id_user { get => id_user; set => id_user = value; }
        public string Body { get => body; set => body = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
