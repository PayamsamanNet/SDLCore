using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class CustomerTypeServices
    {
        private readonly ICustomerTypeRepository _customerTypeRepository;
        private readonly IMapper _mapper;

        public CustomerTypeServices(ICustomerTypeRepository customerTypeRepository, IMapper mapper)
        {
            _customerTypeRepository = customerTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerTypeDto>> GetAll()
        {
            try
            {
                var customerType = await _customerTypeRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<CustomerTypeDto>>(customerType);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<CustomerTypeDto> GetById(Guid Id)
        {
            try
            {
                var customerType = await _customerTypeRepository.GetByIdAsync(Id);
                return _mapper.Map<CustomerTypeDto>(customerType);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(CustomerTypeDto customerTypeDto)
        {
            try
            {
              
                var customerType = _mapper.Map<CustomerType>(customerTypeDto);
                return await _customerTypeRepository.AddAsync(customerType);
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
                var ExistCustomerType = await _customerTypeRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistCustomerType)
                {
                    var customerType = _mapper.Map<CustomerType>(new CustomerTypeDto { Id = Id });
                    return await _customerTypeRepository.DeleteAsync(customerType);
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

        public async Task<ServiceResult> Update(CustomerTypeDto customerTypeDto)
        {
            try
            {
                var customerType = _mapper.Map<CustomerType>(customerTypeDto);
                return await _customerTypeRepository.UpdateAsync(customerType);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }
    }
}
