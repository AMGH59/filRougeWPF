using devTalksWPF.Interfaces;
using devTalksWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Repositories
{
    class MessageRepository : BaseRepository,IRepository<Message>
    {
        public MessageRepository(DataContext dataContext) : base(dataContext) { }

        public Message FinById(int id)
        {
            return _dataContext.Messages.Find(id);
        }
        public bool Save(Message message)
        {
            _dataContext.Messages.Add(message);
            return _dataContext.SaveChanges() > 0;
        }

        public IEnumerable<Message> Search(Func<Message, bool> predicate)
        {
            return _dataContext.Messages.Where(m=>predicate(m)).ToList();
        }

        public bool Update(Message message)
        {
            return _dataContext.SaveChanges() > 0;
        }

        public bool Remove(Message message)
        {
            _dataContext.Messages.Remove(message);
            return _dataContext.SaveChanges() > 0;
        }

        public IEnumerable<Message> Search(Expression<Func<Message, bool>> predicate)
        {
            return _dataContext.Messages.Where(predicate).ToList();

        }

        public Message SearchOne(Expression<Func<Message, bool>> searchMethode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
