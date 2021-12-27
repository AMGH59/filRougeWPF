using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Classes
{
    public class Message
    {
        private int id;
        private string body;
        private DateTime date;
        private int id_topic;
        private int id_user;


        [ForeignKey("Id_topic")]
        public virtual Topic topic { get; set; }
        [ForeignKey("Id_user")]
        public virtual User user { get; set; }


        public enum StateMessageEnum
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
        public StateMessageEnum StateMessage { get; set; }
    }
}
