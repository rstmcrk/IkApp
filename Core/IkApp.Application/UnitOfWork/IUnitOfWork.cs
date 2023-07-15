using IkApp.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkApp.Application.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository AddressRepository { get; }
        IAnnouncementRepository AnnouncementRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IEmplooyeLoanedItemRepository EmplooyeLoanedItemRepository { get; }
        IEmployeeChildRepository EmployeeChildRepository { get; }
        IEmployeeDetailRepository EmployeeDetailRepository { get; }
        IProductTypeRepository ProductTypeRepository { get; }
        ISectionRepository SectionRepository { get; }
        ITaskRepository TaskRepository { get; }
        void Commit();
    }
}
