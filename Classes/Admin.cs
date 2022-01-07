using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Classes
{
    public class Admin : User
    {
        public Admin() : base()
        {

        }

        public bool BanUser(int id)
        {
            return false;
        }

        public bool AddUser(User user)
        {
            return false;
        }

        public bool AcceptUser(int id)
        {
            return false;
        }

        public bool RefuseUser(int id)
        {
            return false;
        }

        public bool AcceptMessage(int id)
        {
            return false;
        }

        public bool RefuseMessage(int id)
        {
            return false;
        }
        public bool DeactivateMessage(int id)
        {
            return false;
        }



    }
}