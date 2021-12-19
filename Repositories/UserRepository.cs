using devTalksWPF.Classes;
using devTalksWPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Repositories
{
    class UserRepository : IRepository<User>
    {
        public User FinById(int id)
        {
            return DataContext.Instance.Users.Find(id);
        }

        public bool Save(User user)
        {
            DataContext.Instance.Users.Add(user);
            return DataContext.Instance.SaveChanges() > 0;
        }

        public IEnumerable<User> Search(Func<User, bool> predicate)
        {
            return DataContext.Instance.Users.Where(u => predicate(u)).ToList();
        }

        public bool Update(User user)
        {
            return DataContext.Instance.SaveChanges() > 0;
        }

    }
}
