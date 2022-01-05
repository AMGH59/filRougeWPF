using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devTalksWPF.Classes
{
    public class Forum
    {
        private List<Topic> topics;
        private List<User> users;
        //private Admin admin;
        private Topic topic;

        public Forum()
        {

        }


        public List<Topic> Topics { get => topics; set => topics = value; }
        public List<User> Users { get => users; set => users = value; }
        //public Admin Admin { get => admin; set => admin = value; }
        public Topic Topic { get => topic; set => topic = value; }
    }
}

