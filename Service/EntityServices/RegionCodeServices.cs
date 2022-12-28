using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class RegionCodeServices
    {
        private readonly IRegionCodeRepository _regionCodeRepository;
        private readonly IMapper _mapper;

        public RegionCodeServices(IRegionCodeRepository regionCodeRepository, IMapper mapper)
        {
            _regionCodeRepository = regionCodeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegionCodeDto>> GetAll()
        {
            try
            {
                var regionCode = await _regionCodeRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<RegionCodeDto>>(regionCode);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<RegionCodeDto> GetById(Guid Id)
        {
            try
            {
                var regionCode = await _regionCodeRepository.GetByIdAsync(Id);
                return _mapper.Map<RegionCodeDto>(regionCode);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(RegionCodeDto regionCodeDto)
        {
            try
            {
                regionCodeDto.Id = Guid.NewGuid();
                var regionCode = _mapper.Map<RegionCode>(regionCodeDto);
                return await _regionCodeRepository.AddAsync(regionCode);
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
                var ExistRegionCode = await _regionCodeRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistRegionCode)
                {
                    var regionCode = _mapper.Map<RegionCode>(new RegionCodeDto { Id = Id });
                    return await _regionCodeRepository.DeleteAsync(regionCode);
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

        public async Task<ServiceResult> Update(RegionCodeDto regionCodeDto)
        {
            try
            {
                var regionCode = _mapper.Map<RegionCode>(regionCodeDto);
                return await _regionCodeRepository.UpdateAsync(regionCode);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }

    }
}
