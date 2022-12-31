using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class LegalCustomerServices
    {
        private readonly ILegalCustomerRepository _legalCustomerRepository;
        private readonly IMapper _mapper;

        public LegalCustomerServices(ILegalCustomerRepository legalCustomerRepository, IMapper mapper)
        {
            _legalCustomerRepository = legalCustomerRepository;
            _mapper = mapper;

        }

        public async Task<IEnumerable<LegalCustomerDto>> GetAll()
        {
            try
            {
                var legalCustomer = await _legalCustomerRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<LegalCustomerDto>>(legalCustomer);

            }
            catch (Exception)
            {

                return null;
            }
        }


        public async Task<LegalCustomerDto> GetById(Guid Id)
        {
            try
            {
                var legalCustomer = await _legalCustomerRepository.GetByIdAsync(Id);
                return _mapper.Map<LegalCustomerDto>(legalCustomer);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(LegalCustomerDto legalCustomerDto)
        {
            try
            {
               
                var legalCustomer = _mapper.Map<LegalCustomer>(legalCustomerDto);
                return await _legalCustomerRepository.AddAsync(legalCustomer);
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
                var ExistLegalCustomer = await _legalCustomerRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistLegalCustomer)
                {
                    var legalCustomer = _mapper.Map<LegalCustomer>(new LegalCustomerDto { Id = Id });
                    return await _legalCustomerRepository.DeleteAsync(legalCustomer);
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

        public async Task<ServiceResult> Update(LegalCustomerDto legalCustomerDto)
        {
            try
            {
                var legalCustomer = _mapper.Map<LegalCustomer>(legalCustomerDto);
                return await _legalCustomerRepository.UpdateAsync(legalCustomer);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }

    }
}
