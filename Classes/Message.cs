using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devTalksWPF.Classes
{
    public class Message
    {
        private int id;
        private string body;
        private DateTime date;
        public int Id_topic { get; set; }
        public int Id_user { get; set; }


        [ForeignKey("Id_topic")]
        public virtual Topic Topic { get; set; }
        [ForeignKey("Id_user")]
        public virtual User User { get; set; }


        public enum StateMessageEnum
        {
            Reported,
            Accept,
            Disallow
        }
        public Message()
        {
            Date = DateTime.Now;
            StateMessage = StateMessageEnum.Accept;
        }
        public int Id { get => id; set => id = value; }
        public string Body { get => body; set => body = value; }
        public DateTime Date { get => date; set => date = value; }
        public StateMessageEnum StateMessage { get; set; }
    }
}

