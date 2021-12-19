using devTalksWPF.Classes;
using devTalksWPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Repositories
{
    class TopicRepository : IRepository<Topic>
    {
        public Topic FinById(int id)
        {
            return DataContext.Instance.Topics.Find(id);
        }

        public bool Save(Topic topic)
        {
            DataContext.Instance.Topics.Add(topic);
            return DataContext.Instance.SaveChanges() > 0;
        }

        public IEnumerable<Topic> Search(Func<Topic, bool> predicate)
        {
            return DataContext.Instance.Topics.Where(m => predicate(m)).ToList();
        }

        public bool Update(Topic topic)
        {
            return DataContext.Instance.SaveChanges() > 0;
        }

        public bool Remove(Topic topic)
        {
            DataContext.Instance.Topics.Remove(topic);
            return DataContext.Instance.SaveChanges() > 0;
        }
    }
}
