using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.DataAccess.UnitOfWork;
using Udemy.TodoAppNTier.Dtos.WorkDtos;
using Udemy.TodoAppNTier.Entities.Domains;

namespace Udemy.TodoAppNTier.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public WorkService(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<List<WorkListDto>> GetAll()
        {
            //var list = await _uow.GetRepository<Work>().GetAll();

            //var workList = new List<WorkListDto>();

            //if (list != null && list.Count > 0)
            //{
            //    foreach (var work in list)
            //    {
            //        workList.Add(new()
            //        {
            //            Defination = work.Defination,
            //            Id = work.Id,
            //            IsCompleted = work.IsCompleted
            //        });
            //    }
            //}

            return _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
        }

        public async Task Create(WorkCreateDto dto)
        {
            await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
            await _uow.SaveChanges();
        }

        public async Task<WorkListDto> GetById(int id)
        {
            //await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id);
            //return new WorkListDto()
            //{
            //    Defination = work.Defination,
            //    Id = work.Id,
            //    IsCompleted = work.IsCompleted
            //};
            return _mapper.Map<WorkListDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));
        }

        public async Task Remove(int id)
        {

            _uow.GetRepository<Work>().Remove(id);
            _uow.SaveChanges();
        }

        public async Task Update(WorkUpdateDto dto)
        {
            //_uow.GetRepository<Work>().Update(new Work()
            //{
            //    Defination = dto.Defination,
            //    Id = dto.Id,
            //    IsCompleted = dto.IsCompleted
            //});
            //await _uow.SaveChanges();
            _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto));
            await _uow.SaveChanges();
        }
    }
}
