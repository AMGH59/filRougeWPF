using devTalksWPF.Interfaces;
using devTalksWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Repositories
{
    class MessageRepository : IRepository<Message>
    {
        public Message FinById(int id)
        {
            return DataContext.Instance.Messages.Find(id);
        }

        public bool Save(Message message)
        {
            DataContext.Instance.Messages.Add(message);
            return DataContext.Instance.SaveChanges()>0;
        }

        public IEnumerable<Message> Search(Func<Message, bool> predicate)
        {
            return DataContext.Instance.Messages.Where(m=>predicate(m)).ToList();
        }

        public bool Update(Message message)
        {
            return DataContext.Instance.SaveChanges() > 0;
        }

        public bool Remove(Message message)
        {
            DataContext.Instance.Messages.Remove(message);
            return DataContext.Instance.SaveChanges() > 0;
        }
    }
}
