using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Classes
{
    public class User
    {
        private int id;
        private string firstName, lastName, email, password;
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
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}
