using devTalksWPF.Classes;
using devTalksWPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Repositories
{
    class TopicRepository : BaseRepository,IRepository<Topic>
    {
        public Topic FinById(int id)
        {
            return _dataContext.Instance.Topics.Find(id);
        }

        public bool Save(Topic topic)
        {
            _dataContext.Instance.Topics.Add(topic);
            return _dataContext.Instance.SaveChanges() > 0;
        }

        public IEnumerable<Topic> Search(Func<Topic, bool> predicate)
        {
            return _dataContext.Instance.Topics.Where(m => predicate(m)).ToList();
        }

        public bool Update(Topic topic)
        {
            return _dataContext.Instance.SaveChanges() > 0;
        }

        public bool Remove(Topic topic)
        {
            _dataContext.Instance.Topics.Remove(topic);
            return _dataContext.Instance.SaveChanges() > 0;
        }
    }
}
