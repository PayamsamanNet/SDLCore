using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<BranchDto>> GetAll()
        {
            try
            {
                var branch = await _branchRepository.Entities.Include(f => f.Bank).Include(d => d.BranchManager).ToListAsync();
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
                var branch = await _branchRepository.Table.Include(d => d.BranchAddress).
                    FirstOrDefaultAsync(e=>e.Id == Id);
                return _mapper.Map<BranchDto>(branch);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(BranchDto branchDto, [FromServices] IAddressRepository addressRepository)
        {
            try
            {
                var adress = _mapper.Map<AddressDto, Address>(branchDto.BranchAddress);
                var AddSaveAddress = await addressRepository.SaveAndReturnId(adress);
                if (AddSaveAddress != null)
                {
                    branchDto.BranchAddressId = AddSaveAddress.Id;
                    branchDto.BranchManager = null;
                    branchDto.Bank = null;
                    branchDto.Degree = null;
                    branchDto.RegionCode = null;
                    branchDto.BranchAddress = null;
                    var branch = _mapper.Map<Branch>(branchDto);
                    return await _branchRepository.AddAsync(branch);
                }
                return null;



            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError,null);
            }

        }

        public async Task<ServiceResult> Delete(Guid Id, [FromServices] IAddressRepository addressRepository)
        {
            try
            {
                var ExistBranch = await _branchRepository.Table.FirstOrDefaultAsync(s => s.Id == Id);
                if (ExistBranch != null)
                {
                   
                    var result = await _branchRepository.DeleteAsync(ExistBranch);
                    if (result.Status == ResponseStatus.Success)
                    {
                        return await addressRepository.DeleteAsync(new Address { Id= ExistBranch.BranchAddressId});
                    }
                    return new ServiceResult(ResponseStatus.NotFound,null);

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

        public async Task<ServiceResult> Update(BranchDto branchDto , [FromServices] IAddressRepository addressRepository)
        {
            try
            {
                var Address = _mapper.Map<AddressDto, Address>(branchDto.BranchAddress);
                var updateAddress = await addressRepository.UpdateAsync(Address);
                if (updateAddress.Status != ResponseStatus.Success)
                {
                    return new ServiceResult(ResponseStatus.BadRequest,null);
                }
                var branch = _mapper.Map<Branch>(branchDto);
                branchDto.BranchAddressId = Address.Id;
                branchDto.BranchManager = null;
                branchDto.Bank = null;
                branchDto.Degree = null;
                branchDto.RegionCode = null;
                branchDto.BranchAddress = null;
                return await _branchRepository.UpdateAsync(branch);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError,null);
            }
        }
    }
}
