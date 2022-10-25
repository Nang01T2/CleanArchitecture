using {{ cookiecutter.assembly_name }}.Application.Contracts.Persistence;
using {{ cookiecutter.assembly_name }}.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace {{ cookiecutter.assembly_name }}.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly {{ cookiecutter.assembly_name }}DbContext _dbContext;

        public LeaveTypeRepository({{ cookiecutter.assembly_name }}DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
