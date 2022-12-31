using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class AgreementServices
    {
        private readonly IAgreementRepository _agreementRepository;
        private readonly IMapper _mapper;

        public AgreementServices(IAgreementRepository agreementRepository, IMapper mapper)
        {
            _agreementRepository = agreementRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AgreementDto>> GetAll()
        {
            try
            {
                var agreement = await _agreementRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<AgreementDto>>(agreement);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<AgreementDto> GetById(Guid Id)
        {
            try
            {
                var agreement = await _agreementRepository.GetByIdAsync(Id);
                return _mapper.Map<AgreementDto>(agreement);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(AgreementDto agreementDto)
        {
            try
            {
               
                var agreement = _mapper.Map<Agreement>(agreementDto);
                return await _agreementRepository.AddAsync(agreement);
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
                var ExistAgreement = await _agreementRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistAgreement)
                {
                    var city = _mapper.Map<Agreement>(new AgreementDto { Id = Id });
                    return await _agreementRepository.DeleteAsync(city);
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

        public async Task<ServiceResult> Update(AgreementDto agreementDto)
        {
            try
            {
                var agreement = _mapper.Map<Agreement>(agreementDto);
                return await _agreementRepository.UpdateAsync(agreement);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }

    }
}
