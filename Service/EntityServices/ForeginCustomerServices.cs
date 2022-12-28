using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class ForeginCustomerServices
    {
        private readonly IForeignCustomerRepository _foreignCustomerRepository;
        private readonly IMapper _mapper;

        public ForeginCustomerServices(IForeignCustomerRepository foreignCustomerRepository, IMapper mapper)
        {
            _foreignCustomerRepository = foreignCustomerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ForeignCustomerDto>> GetAll()
        {
            try
            {
                var foreginCustomer = await _foreignCustomerRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<ForeignCustomerDto>>(foreginCustomer);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ForeignCustomerDto> GetById(Guid Id)
        {
            try
            {
                var foreginCustomer = await _foreignCustomerRepository.GetByIdAsync(Id);
                return _mapper.Map<ForeignCustomerDto>(foreginCustomer);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(ForeignCustomerDto foreignCustomerDto)
        {
            try
            {
                foreignCustomerDto.Id = Guid.NewGuid();
                var foreginCustomer = _mapper.Map<ForeignCustomer>(foreignCustomerDto);
                return await _foreignCustomerRepository.AddAsync(foreginCustomer);
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
                var ExistForegionCustomer = await _foreignCustomerRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistForegionCustomer)
                {
                    var foreginCustomer = _mapper.Map<ForeignCustomer>(new ForeignCustomerDto { Id = Id });
                    return await _foreignCustomerRepository.DeleteAsync(foreginCustomer);
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

        public async Task<ServiceResult> Update(ForeignCustomerDto foreignCustomerDto)
        {
            try
            {
                var foreginCustomer = _mapper.Map<ForeignCustomer>(foreignCustomerDto);
                return await _foreignCustomerRepository.UpdateAsync(foreginCustomer);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }
    }
}
