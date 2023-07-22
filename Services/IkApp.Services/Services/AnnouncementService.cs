using IkApp.Application.Services;
using IkApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Services.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        public void Add(Announcement entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Announcement> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Announcement> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Announcement entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Announcement entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Announcement> Where(Expression<Func<Announcement, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
