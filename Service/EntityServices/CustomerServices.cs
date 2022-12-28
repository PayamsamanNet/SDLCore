using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class CustomerServices
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerServices(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            try
            {
                var customer = await _customerRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<CustomerDto>>(customer);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<CustomerDto> GetById(Guid Id)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(Id);
                return _mapper.Map<CustomerDto>(customer);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(CustomerDto customerDto)
        {
            try
            {
                customerDto.Id = Guid.NewGuid();
                var customer = _mapper.Map<Customer>(customerDto);
                return await _customerRepository.AddAsync(customer);
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
                var ExistCustomer = await _customerRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistCustomer)
                {
                    var customer = _mapper.Map<Customer>(new CustomerDto { Id = Id });
                    return await _customerRepository.DeleteAsync(customer);
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

        public async Task<ServiceResult> Update(CustomerDto customerDto)
        {
            try
            {
                var customer = _mapper.Map<Customer>(customerDto);
                return await _customerRepository.UpdateAsync(customer);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }
    }
}
