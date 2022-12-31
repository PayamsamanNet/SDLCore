using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class BoxTypeServices
    {
        private readonly IBoxTypeRepository _boxTypeRepository;
        private readonly IMapper _mapper;

        public BoxTypeServices(IBoxTypeRepository boxTypeRepository, IMapper mapper)
        {
            _boxTypeRepository = boxTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BoxTypeDto>> GetAll()
        {
            try
            {
                var boxType = await _boxTypeRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<BoxTypeDto>>(boxType);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<BoxTypeDto> GetById(Guid Id)
        {
            try
            {
                var boxType = await _boxTypeRepository.GetByIdAsync(Id);
                return _mapper.Map<BoxTypeDto>(boxType);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(BoxTypeDto boxTypeDto)
        {
            try
            {
               
                var boxType = _mapper.Map<BoxType>(boxTypeDto);
                return await _boxTypeRepository.AddAsync(boxType);
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
                var ExistBoxType = await _boxTypeRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistBoxType)
                {
                    var box = _mapper.Map<BoxType>(new BoxTypeDto { Id = Id });
                    return await _boxTypeRepository.DeleteAsync(box);
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

        public async Task<ServiceResult> Update(BoxTypeDto boxTypeDto)
        {
            try
            {
                var boxType = _mapper.Map<BoxType>(boxTypeDto);
                return await _boxTypeRepository.UpdateAsync(boxType);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }
    }
}
