using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class LogServices
    {
        private readonly IlogRepository _ilogRepository;
        private readonly IMapper _mapper;

        public LogServices(IlogRepository ilogRepository, IMapper mapper)
        {
            _ilogRepository = ilogRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LogDto>> GetAll()
        {
            try
            {
                var log = await _ilogRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<LogDto>>(log);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<LogDto> GetById(Guid Id)
        {
            try
            {
                var log = await _ilogRepository.GetByIdAsync(Id);
                return _mapper.Map<LogDto>(log);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(LogDto logDto)
        {
            try
            {
               
                var log = _mapper.Map<Log>(logDto);
                return await _ilogRepository.AddAsync(log);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError,null);
            }

        }

        public async Task<ServiceResult> Delete(Guid Id)
        {
            try
            {
                var ExistLog = await _ilogRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistLog)
                {
                    var log = _mapper.Map<Log>(new LogDto { Id = Id });
                    return await _ilogRepository.DeleteAsync(log);
                }
                else
                {
                    return new ServiceResult(ResponseStatus.NotFound,null);
                }
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError,null);
            }
        }

        public async Task<ServiceResult> Update(LogDto logDto)
        {
            try
            {
                var log = _mapper.Map<Log>(logDto);
                return await _ilogRepository.UpdateAsync(log);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError,null);
            }
        }
    }
}
