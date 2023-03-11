using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class StateServices
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;

        public StateServices(IStateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<StateDto>> GetAll()
        {
            try
            {
                var state = await _stateRepository.Entities.ToListAsync();
                return _mapper.Map<List<StateDto>>(state);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<StateDto> GetById(Guid Id)
        {
            try
            {
                var address = await _stateRepository.GetByIdAsync(Id);
                return _mapper.Map<StateDto>(address);

            }
            catch (Exception)
            {

                return null;
            }

        }
        public async Task<ServiceResult> Create(StateDto stateDto)
        {
            try
            {
                if (await _stateRepository.TableNoTracking.AnyAsync(s=>s.StateCode == stateDto.StateCode))
                {
                    return new ServiceResult(ResponseStatus.BadRequest, "کد استان تکراری است ");
                }


                var state = _mapper.Map<State>(stateDto);
                return await _stateRepository.AddAsync(state);

            }
            catch (Exception)
            {
                return new ServiceResult(ResponseStatus.ServerError,null);
            }
        }
        public async Task<ServiceResult> Update(StateDto stateDto)
        {
            try
            {
                var state = _mapper.Map<State>(stateDto);
                return await _stateRepository.UpdateAsync(state);

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
                var ExsitState = await _stateRepository.Table.AnyAsync(d => d.Id == Id);
                if (ExsitState)
                {
                    var state = _mapper.Map<State>(new StateDto { Id = Id });
                    return await _stateRepository.DeleteAsync(state);
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
    }
}
