using devTalksWPF.Classes;
using devTalksWPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Repositories
{
    class UserRepository : BaseRepository,IRepository<User>
    {
        public User FinById(int id)
        {
            return _dataContext.Instance.Users.Find(id);
        }

        public bool Save(User user)
        {
            _dataContext.Instance.Users.Add(user);
            return _dataContext.Instance.SaveChanges() > 0;
        }

        public IEnumerable<User> Search(Func<User, bool> predicate)
        {
            return _dataContext.Instance.Users.Where(u => predicate(u)).ToList();
        }

        public bool Update(User user)
        {
            return _dataContext.Instance.SaveChanges() > 0;
        }

    }
}
