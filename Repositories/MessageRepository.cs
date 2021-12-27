using devTalksWPF.Interfaces;
using devTalksWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Repositories
{
    class MessageRepository : BaseRepository,IRepository<Message>
    {
        public Message FinById(int id)
        {
            return _dataContext.Instance.Messages.Find(id);
        }

        public bool Save(Message message)
        {
            _dataContext.Instance.Messages.Add(message);
            return _dataContext.Instance.SaveChanges()>0;
        }

        public IEnumerable<Message> Search(Func<Message, bool> predicate)
        {
            return _dataContext.Instance.Messages.Where(m=>predicate(m)).ToList();
        }

        public bool Update(Message message)
        {
            return _dataContext.Instance.SaveChanges() > 0;
        }

        public bool Remove(Message message)
        {
            _dataContext.Instance.Messages.Remove(message);
            return _dataContext.Instance.SaveChanges() > 0;
        }
    }
}
