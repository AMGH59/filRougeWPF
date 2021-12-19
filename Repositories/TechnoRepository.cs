using devTalksWPF.Classes;
using devTalksWPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devTalksWPF.Repositories
{
    class TechnoRepository : IRepository<Techno>
    {
        public Techno FinById(int id)
        {
            return DataContext.Instance.Technos.Find(id);
        }

        public bool Save(Techno techno)
        {
            DataContext.Instance.Technos.Add(techno);
            return DataContext.Instance.SaveChanges() > 0;
        }

        public IEnumerable<Techno> Search(Func<Techno, bool> predicate)
        {
            return DataContext.Instance.Technos.Where(t => predicate(t)).ToList();
        }

        public bool Update(Techno element)
        {
            return DataContext.Instance.SaveChanges() > 0;

        }
    }
}
