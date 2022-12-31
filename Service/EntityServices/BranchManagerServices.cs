using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class BranchManagerServices
    {
        private readonly IBranchManagerRepository _branchManagerRepository;
        private readonly IMapper _mapper;

        public BranchManagerServices(IBranchManagerRepository branchManagerRepository, IMapper mapper)
        {
            _branchManagerRepository = branchManagerRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BranchManagerDto>> GetAll()
        {
            try
            {
                var branchManager = await _branchManagerRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<BranchManagerDto>>(branchManager);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<BranchManagerDto> GetById(Guid Id)
        {
            try
            {
                var branchManage = await _branchManagerRepository.GetByIdAsync(Id);
                return _mapper.Map<BranchManagerDto>(branchManage);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(BranchManagerDto branchManagerDto)
        {
            try
            {
                var branchManager = _mapper.Map<BranchManager>(branchManagerDto);
                return await _branchManagerRepository.AddAsync(branchManager);
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
                var ExistBrachManager = await _branchManagerRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistBrachManager)
                {
                    var branchManagerDto = _mapper.Map<BranchManager>(new BranchManagerDto { Id = Id });
                    return await _branchManagerRepository.DeleteAsync(branchManagerDto);
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

        public async Task<ServiceResult> Update(BranchManagerDto branchManagerDto)
        {
            try
            {
                var branchManager = _mapper.Map<BranchManager>(branchManagerDto);
                return await _branchManagerRepository.UpdateAsync(branchManager);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }
    }
}
