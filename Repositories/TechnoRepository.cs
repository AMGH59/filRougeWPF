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
    class TechnoRepository : BaseRepository,IRepository<Techno>
    {
        public TechnoRepository(DataContext dataContext) : base(dataContext) { }
        public Techno FinById(int id)
        {
            return _dataContext.Technos.Find(id);
        }

        public IEnumerable<Techno> GetAll()
        {
            return _dataContext.Technos.ToList();
        }

        public bool Save(Techno techno)
        {
            _dataContext.Technos.Add(techno);
            return _dataContext.SaveChanges() > 0;
        }

        public IEnumerable<Techno> Search(Func<Techno, bool> predicate)
        {
            return _dataContext.Technos.Where(t => predicate(t)).ToList();
        }

        public IEnumerable<Techno> Search(Expression<Func<Techno, bool>> predicate)
        {
            return _dataContext.Technos.Where(predicate).ToList();
        }

        public Techno SearchOne(Expression<Func<Techno, bool>> searchMethode)
        {
            throw new NotImplementedException();
        }

        public bool Update(Techno element)
        {
            return _dataContext.SaveChanges() > 0;

        }
    }
}
