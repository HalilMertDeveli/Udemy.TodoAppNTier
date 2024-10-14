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
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;
        public WorkService(IUow uow)
        {
            _uow = uow;
        }
        public async Task<List<WorkListDto>> GetAll()
        {
            var list = await _uow.GetRepository<Work>().GetAll();

            var workList = new List<WorkListDto>();

            if (list != null && list.Count > 0)
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

        public async Task Create(WorkCreateDto dto)
        {
            await _uow.GetRepository<Work>().Create(new Work()
            {
                Defination = dto.Defination,
                IsCompleted = dto.IsCompleted
            });
            await _uow.SaveChanges();
        }

        public async Task<WorkListDto> GetById(object id)
        {
            var work = await _uow.GetRepository<Work>().GetById(id);
            return new WorkListDto()
            {
                Defination = work.Defination,
                Id = work.Id,
                IsCompleted = work.IsCompleted
            };
        }

        public async Task Remove(object id)
        {
            var deletedWork = await _uow.GetRepository<Work>().GetById(id);
            _uow.GetRepository<Work>().Remove(deletedWork);
            _uow.SaveChanges();
        }

        public async  Task Update(WorkUpdateDto dto)
        {
            _uow.GetRepository<Work>().Update(new Work()
            {
                Defination = dto.Defination,
                Id = dto.Id,
                IsCompleted = dto.IsCompleted
            });
            await _uow.SaveChanges();
        }
    }
}
