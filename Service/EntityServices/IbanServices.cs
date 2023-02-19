using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class IbanServices
    {

        private readonly IIbanRepository _ibanRepository;
        private readonly IMapper _mapper;
        public IbanServices(IIbanRepository ibanRepository, IMapper mapper)
        {
            _ibanRepository = ibanRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<IbanDto>> GetAll()
        {
            try
            {
                var iban = await _ibanRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<IbanDto>>(iban);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<IbanDto> GetById(Guid Id)
        {
            try
            {
                var iban = await _ibanRepository.GetByIdAsync(Id);
                return _mapper.Map<IbanDto>(iban);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(IbanDto ibanDto)
        {
            try
            {
               
                var iban = _mapper.Map<Iban>(ibanDto);
                return await _ibanRepository.AddAsync(iban);
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
                var ExistIban = await _ibanRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistIban)
                {
                    var iban = _mapper.Map<Iban>(new IbanDto { Id = Id });
                    return await _ibanRepository.DeleteAsync(iban);
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

        public async Task<ServiceResult> Update(IbanDto ibanDto)
        {
            try
            {
                var iban = _mapper.Map<Iban>(ibanDto);
                return await _ibanRepository.UpdateAsync(iban);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError,null);
            }
        }
    }
}
