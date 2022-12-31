using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class RealCustomerServices
    {

        private readonly IRealCustomerRepository _realCustomerRepository;
        private readonly IMapper _mapper;

        public RealCustomerServices(IRealCustomerRepository realCustomerRepository, IMapper mapper)
        {
            _realCustomerRepository = realCustomerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RealCustomerDto>> GetAll()
        {
            try
            {
                var realCustomer = await _realCustomerRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<RealCustomerDto>>(realCustomer);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<RealCustomerDto> GetById(Guid Id)
        {
            try
            {
                var realCustomer = await _realCustomerRepository.GetByIdAsync(Id);
                return _mapper.Map<RealCustomerDto>(realCustomer);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(RealCustomerDto realCustomerDto)
        {
            try
            {
                
                var realCustomer = _mapper.Map<RealCustomer>(realCustomerDto);
                return await _realCustomerRepository.AddAsync(realCustomer);
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
                var ExistRealCustomer = await _realCustomerRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistRealCustomer)
                {
                    var realCustomer = _mapper.Map<RealCustomer>(new RealCustomerDto { Id = Id });
                    return await _realCustomerRepository.DeleteAsync(realCustomer);
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

        public async Task<ServiceResult> Update(RealCustomerDto realCustomerDto)
        {
            try
            {
                var realCustomer = _mapper.Map<RealCustomer>(realCustomerDto);
                return await _realCustomerRepository.UpdateAsync(realCustomer);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }
    }
}
