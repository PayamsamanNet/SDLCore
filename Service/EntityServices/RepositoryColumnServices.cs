using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class RepositoryColumnServices
    {
        private readonly IRepositoryColumnRepository _repositoryColumnRepository;
        private readonly IMapper _mapper;

        public RepositoryColumnServices(IRepositoryColumnRepository repositoryColumnRepository, IMapper mapper)
        {
            _repositoryColumnRepository = repositoryColumnRepository;
            _mapper = mapper;

        }

        public async Task<IEnumerable<RepositoryColumnDto>> GetAll()
        {
            try
            {
                var repositoryColumn = await _repositoryColumnRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<RepositoryColumnDto>>(repositoryColumn);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<RepositoryColumnDto> GetById(Guid Id)
        {
            try
            {
                var repositoryColumn = await _repositoryColumnRepository.GetByIdAsync(Id);
                return _mapper.Map<RepositoryColumnDto>(repositoryColumn);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(RepositoryColumnDto repositoryColumnDto)
        {
            try
            {
                repositoryColumnDto.Id = Guid.NewGuid();
                var repositoryColumn = _mapper.Map<RepositoryColumn>(repositoryColumnDto);
                return await _repositoryColumnRepository.AddAsync(repositoryColumn);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }

        }

        public async Task<ServiceResult> Delete(Guid Id)
        {
            try
            {
                var ExistRepositoryColumn = await _repositoryColumnRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistRepositoryColumn)
                {
                    var repositoryColumn = _mapper.Map<RepositoryColumn>(new RepositoryColumnDto { Id = Id });
                    return await _repositoryColumnRepository.DeleteAsync(repositoryColumn);
                }
                else
                {
                    return new ServiceResult(ResponseStatus.NotFound);
                }
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }

        public async Task<ServiceResult> Update(RepositoryColumnDto repositoryColumnDto)
        {
            try
            {
                var repositoryColumn = _mapper.Map<RepositoryColumn>(repositoryColumnDto);
                return await _repositoryColumnRepository.UpdateAsync(repositoryColumn);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }
    }
}
