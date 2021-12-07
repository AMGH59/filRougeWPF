using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Classes
{
    class User
    {
        private int id;
        private string name, surname, email, password;
        private enum State
        {
            Waiting,
            Accept,
            Ban
        }

        public User()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}
