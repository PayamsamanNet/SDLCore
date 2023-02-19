using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class DegreeServices
    {
        private readonly IDegreeRepository _degreeRepository;
        private readonly IMapper _mapper;

        public DegreeServices(IDegreeRepository degreeRepository, IMapper mapper)
        {
            _degreeRepository = degreeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DegreeDto>> GetAll()
        {
            try
            {

                var degree = await _degreeRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<DegreeDto>>(degree);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<DegreeDto> GetById(Guid Id)
        {
            try
            {
                var degree = await _degreeRepository.GetByIdAsync(Id);
                return _mapper.Map<DegreeDto>(degree);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(DegreeDto degreeDto)
        {
            try
            {
               
                var degree = _mapper.Map<Degree>(degreeDto);
                return await _degreeRepository.AddAsync(degree);
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
                var ExistDegree = await _degreeRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistDegree)
                {
                    var degree = _mapper.Map<Degree>(new DegreeDto { Id = Id });
                    return await _degreeRepository.DeleteAsync(degree);
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

        public async Task<ServiceResult> Update(DegreeDto degreeDto)
        {
            try
            {
                var degree = _mapper.Map<Degree>(degreeDto);
                return await _degreeRepository.UpdateAsync(degree);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError,null);
            }
        }
    }
}
