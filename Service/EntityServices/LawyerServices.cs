using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class LawyerServices
    {

        private readonly IlawyerRepository _ilawyerRepository;
        private readonly IMapper _mapper;
        public LawyerServices(IlawyerRepository ilawyerRepository, IMapper mapper)
        {
            _ilawyerRepository = ilawyerRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LawyerDto>> GetAll()
        {
            try
            {
                var lawyer = await _ilawyerRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<LawyerDto>>(lawyer);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<LawyerDto> GetById(Guid Id)
        {
            try
            {
                var lawyer = await _ilawyerRepository.GetByIdAsync(Id);
                return _mapper.Map<LawyerDto>(lawyer);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(LawyerDto lawyerDto)
        {
            try
            {
                
                var lawyer = _mapper.Map<Lawyer>(lawyerDto);
                return await _ilawyerRepository.AddAsync(lawyer);
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
                var ExistLawyer = await _ilawyerRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistLawyer)
                {
                    var lawyer = _mapper.Map<Lawyer>(new LawyerDto { Id = Id });
                    return await _ilawyerRepository.DeleteAsync(lawyer);
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

        public async Task<ServiceResult> Update(LawyerDto lawyerDto)
        {
            try
            {
                var lawyer = _mapper.Map<Lawyer>(lawyerDto);
                return await _ilawyerRepository.UpdateAsync(lawyer);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError,null);
            }
        }
    }
}
