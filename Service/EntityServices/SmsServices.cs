using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class SmsServices
    {
        private readonly ISmsRepository _smsRepository;
        private readonly IMapper _mapper;

        public SmsServices(ISmsRepository smsRepository, IMapper mapper)
        {
            _smsRepository = smsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SmsDto>> GetAll()
        {
            try
            {
                var sms = await _smsRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<SmsDto>>(sms);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<SmsDto> GetById(Guid Id)
        {
            try
            {
                var sms = await _smsRepository.GetByIdAsync(Id);
                return _mapper.Map<SmsDto>(sms);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(SmsDto smsDto)
        {
            try
            {
                var sms = _mapper.Map<Sms>(smsDto);
                return await _smsRepository.AddAsync(sms);
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
                var ExistSms = await _smsRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistSms)
                {
                    var sms = _mapper.Map<Sms>(new SmsDto { Id = Id });
                    return await _smsRepository.DeleteAsync(sms);
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

        public async Task<ServiceResult> Update(SmsDto smsDto)
        {
            try
            {
                var sms = _mapper.Map<Sms>(smsDto);
                return await _smsRepository.UpdateAsync(sms);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError,null);
            }
        }
    }
}
