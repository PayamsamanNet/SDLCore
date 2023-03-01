using AutoMapper;
using Common.ApiResult;
using Common.Utilities;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class InsuranceServices
    {
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly IMapper _mapper;

        public InsuranceServices(IInsuranceRepository insuranceRepository, IMapper mapper)
        {
            _insuranceRepository = insuranceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InsuranceDto>> GetAll()
        {
            try
            {
                var insurance = await _insuranceRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<InsuranceDto>>(insurance);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<InsuranceDto> GetById(Guid Id)
        {
            try
            {
                var insurance = await _insuranceRepository.GetByIdAsync(Id);
                return _mapper.Map<InsuranceDto>(insurance);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(InsuranceDto insuranceDto)
        {
            try
            {
                
                var insurance = _mapper.Map<Insurance>(insuranceDto);
                insurance.StartDate = ConvertDate.ToMiladi(insuranceDto.StartDate);
                insurance.EndDate = ConvertDate.ToMiladi(insuranceDto.EndDate);
                return await _insuranceRepository.AddAsync(insurance);
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
                var ExistInsurance = await _insuranceRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistInsurance)
                {
                    var insurance = _mapper.Map<Insurance>(new InsuranceDto { Id = Id });
                    return await _insuranceRepository.DeleteAsync(insurance);
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

        public async Task<ServiceResult> Update(InsuranceDto insuranceDto)
        {
            try
            {
                var insurance = _mapper.Map<Insurance>(insuranceDto);
                return await _insuranceRepository.UpdateAsync(insurance);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError,null);
            }
        }
    }
}
