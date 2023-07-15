using IkApp.Application.Repositories;
using IkApp.Application.UnitOfWork;
using IkApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            AddressRepository = new AddressRepository(_context);
            AnnouncementRepository = new AnnouncementRepository(_context);
            DepartmentRepository = new DepartmentRepository(_context);
            EmplooyeLoanedItemRepository = new EmplooyeLoanedItemRepository(_context);
            EmployeeChildRepository = new EmployeeChildRepository(_context);
            EmployeeDetailRepository = new EmployeeDetailRepository(_context);
            ProductTypeRepository = new ProductTypeRepository(_context);
            SectionRepository = new SectionRepository(_context);
            TaskRepository = new TaskRepository(_context);
        }

        public IAddressRepository AddressRepository {get; private set;}

        public IAnnouncementRepository AnnouncementRepository { get; private set; }

        public IDepartmentRepository DepartmentRepository { get; private set; }

        public IEmplooyeLoanedItemRepository EmplooyeLoanedItemRepository { get; private set; }

        public IEmployeeChildRepository EmployeeChildRepository { get; private set; }

        public IEmployeeDetailRepository EmployeeDetailRepository { get; private set; }

        public IProductTypeRepository ProductTypeRepository { get; private set; }

        public ISectionRepository SectionRepository { get; private set; }

        public ITaskRepository TaskRepository { get; private set; }

        public void Commit()
        {
             _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
