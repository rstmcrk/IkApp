using System;
using IkApp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = IkApp.Domain.Entities.Task;

namespace IkApp.Application.Repositories
{
    public interface ITaskRepository : IGenericRepository<Task>
    {
    }
}
