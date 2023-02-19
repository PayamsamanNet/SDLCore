using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class RepositoryServices
    {
        private readonly IRepositoryRepository _repositoryRepository;
        private readonly IMapper _mapper;

        public RepositoryServices(IRepositoryRepository repositoryRepository, IMapper mapper)
        {
            _repositoryRepository = repositoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RepositoryDto>> GetAll()
        {
            try
            {
                var repository = await _repositoryRepository.Entities.Include(d=>d.Bank).Include(f=>f.Degree).ToListAsync();
                return _mapper.Map<List<RepositoryDto>>(repository);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<RepositoryDto> GetById(Guid Id)
        {
            try
            {
                //var repository = await _repositoryRepository.GetByIdAsync(Id);
                var repository = await _repositoryRepository.Table.Include(d=>d.Address).FirstOrDefaultAsync(s=>s.Id == Id);
                return _mapper.Map<RepositoryDto>(repository);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(RepositoryDto repositoryDto)
        {
            try
            {
                 
                var repository = _mapper.Map<Repository>(repositoryDto);
                return await _repositoryRepository.AddAsync(repository);
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
                var ExistRepository = await _repositoryRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistRepository)
                {
                    var repository = _mapper.Map<Repository>(new RepositoryDto { Id = Id });
                    return await _repositoryRepository.DeleteAsync(repository);
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

        public async Task<ServiceResult> Update(RepositoryDto repositoryDto)
        {
            try
            {
                var repository = _mapper.Map<Repository>(repositoryDto);
                return await _repositoryRepository.UpdateAsync(repository);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError,null);
            }
        }
    }
}
