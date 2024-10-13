using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.DataAccess.UnitOfWork;
using Udemy.TodoAppNTier.Dtos.WorkDtos;
using Udemy.TodoAppNTier.Entities.Domains;

namespace Udemy.TodoAppNTier.Business.Services
{
    public class WorkService:IWorkService
    {
        private readonly IUow _uow;
        public WorkService(IUow uow)
        {
            _uow = uow;
        }
        public async Task<List<WorkListDto>> GetAll()
        {
            var list= await _uow.GetRepository<Work>().GetAll();

            var workList = new List<WorkListDto>();

            if (list!=null && list.Count>0)
            {
                foreach (var work in list)
                {
                    workList.Add(new()
                    {
                        Defination = work.Defination,
                        Id = work.Id,
                        IsCompleted = work.IsCompleted
                    });
                }
            }

            return workList;
        }
    }
}
