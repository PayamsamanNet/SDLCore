using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class AgreementDetailServices
    {
        private readonly IAgreementDetailRepository _agreementDetailRepository;
        private readonly IMapper _mapper;

        public AgreementDetailServices(IAgreementDetailRepository agreementDetailRepository, IMapper mapper)
        {
            _agreementDetailRepository = agreementDetailRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AgreementDetailDto>> GetAll()
        {
            try
            {
                var agreementDetail = await _agreementDetailRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<AgreementDetailDto>>(agreementDetail);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<AgreementDetailDto> GetById(Guid Id)
        {
            try
            {
                var agreementDetail = await _agreementDetailRepository.GetByIdAsync(Id);
                return _mapper.Map<AgreementDetailDto>(agreementDetail);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(AgreementDetailDto agreementDetailDto)
        {
            try
            {
                 agreementDetailDto.Id = Guid.NewGuid();
                var agreementDetail = _mapper.Map<AgreementDetail>(agreementDetailDto);
                return await _agreementDetailRepository.AddAsync(agreementDetail);
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
                var ExistAgreementDetail = await _agreementDetailRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistAgreementDetail)
                {
                    var agreementDetail = _mapper.Map<AgreementDetail>(new AgreementDetailDto { Id = Id });
                    return await _agreementDetailRepository.DeleteAsync(agreementDetail);
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

        public async Task<ServiceResult> Update(AgreementDetailDto agreementDetailDto)
        {
            try
            {
                var agreementDetail = _mapper.Map<AgreementDetail>(agreementDetailDto);
                return await _agreementDetailRepository.UpdateAsync(agreementDetail);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }
    }
}
