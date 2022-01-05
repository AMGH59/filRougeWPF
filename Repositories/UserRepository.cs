using devTalksWPF.Classes;
using devTalksWPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace devTalksWPF.Repositories
{
    class UserRepository : BaseRepository,IRepository<User>
    {
        public UserRepository(DataContext dataContext) : base(dataContext) { }

        public User FinById(int id)
        {
            return _dataContext.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(User user)
        {
            _dataContext.Users.Add(user);
            return _dataContext.SaveChanges() > 0;
        }

        public IEnumerable<User> Search(Func<User, bool> predicate)
        {
            return _dataContext.Users.Where(u => predicate(u)).ToList();
        }

        public IEnumerable<User> Search(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public User SearchOne(Expression<Func<User, bool>> searchMethode)
        {
            return _dataContext.Users.FirstOrDefault(searchMethode);
        }

        public bool Update(User user)
        {
            return _dataContext.SaveChanges() > 0;
        }

    }
}
