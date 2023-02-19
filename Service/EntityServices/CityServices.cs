using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class CityServices
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityServices(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CityDto>> GetAll()
        {
            try
            {
                var city = await _cityRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<CityDto>>(city);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<CityDto> GetById(Guid Id)
        {
            try
            {
                var city = await _cityRepository.GetByIdAsync(Id);
                return _mapper.Map<CityDto>(city);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(CityDto cityDto)
        {
            try
            {
         
                var city = _mapper.Map<City>(cityDto);
                return await _cityRepository.AddAsync(city);
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
                var ExistCity = await _cityRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistCity)
                {
                    var city = _mapper.Map<City>(new CityDto { Id = Id });
                    return await _cityRepository.DeleteAsync(city);
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

        public async Task<ServiceResult> Update(CityDto cityDto)
        {
            try
            {
                var city = _mapper.Map<City>(cityDto);
                return await _cityRepository.UpdateAsync(city);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError,null);
            }
        }
    }
}
