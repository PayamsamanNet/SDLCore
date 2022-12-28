using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class BranchServices
    {

        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public BranchServices(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BranchDto>> GetAll()
        {
            try
            {
                var branch = await _branchRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<BranchDto>>(branch);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<BranchDto> GetById(Guid Id)
        {
            try
            {
                var branch = await _branchRepository.GetByIdAsync(Id);
                return _mapper.Map<BranchDto>(branch);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(BranchDto branchDto)
        {
            try
            {
                branchDto.Id = Guid.NewGuid();
                var branch = _mapper.Map<Branch>(branchDto);
                return await _branchRepository.AddAsync(branch);
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
                var ExistBranch = await _branchRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistBranch)
                {
                    var branch = _mapper.Map<Branch>(new BranchDto { Id = Id });
                    return await _branchRepository.DeleteAsync(branch);
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

        public async Task<ServiceResult> Update(BranchDto branchDto)
        {
            try
            {
                var branch = _mapper.Map<Branch>(branchDto);
                return await _branchRepository.UpdateAsync(branch);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }
    }
}
