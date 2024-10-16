using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.Business.ValidationRules;
using Udemy.TodoAppNTier.DataAccess.UnitOfWork;
using Udemy.TodoAppNTier.Dtos.Interfaces;
using Udemy.TodoAppNTier.Dtos.WorkDtos;
using Udemy.TodoAppNTier.Entities.Domains;

namespace Udemy.TodoAppNTier.Business.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<WorkCreateDto> _createDtoValidator;
        private readonly IValidator<WorkUpdateDto> _updateDtoValidator;
        public WorkService(IUow uow, IMapper mapper, IValidator<WorkUpdateDto> updateDtoValidator, IValidator<WorkCreateDto> createDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _updateDtoValidator = updateDtoValidator;
            _createDtoValidator = createDtoValidator;
        }
        public async Task<List<WorkListDto>> GetAll()
        {
            

            return _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
        }

        public async Task Create(WorkCreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
          
            if (validationResult.IsValid)
            {
                await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
                await _uow.SaveChanges();
            }


           
        }

        public async Task<IDto> GetById<IDto>(int id)
        {
            
            return _mapper.Map<IDto>(await _uow.GetRepository<Work>().GetByFilter(x => x.Id == id));
        }

        public async Task Remove(int id)
        {

            _uow.GetRepository<Work>().Remove(id);
            await _uow.SaveChanges();
        }

        public async Task Update(WorkUpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto));
                await _uow.SaveChanges();
            }
            
        }
    }
}
