using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class BankServices
    {

        private readonly IBankRepository _bankRepositorybank;
        private readonly IMapper _mapper;

        public BankServices(IBankRepository bankRepositorybank, IMapper mapper)
        {
            _bankRepositorybank = bankRepositorybank;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BankDto>> GetAll()
        {
            try
            {
                var bank = await _bankRepositorybank.Entities.ToArrayAsync();
                return _mapper.Map<List<BankDto>>(bank);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<BankDto> GetById(Guid Id)
        {
            try
            {
                var bank = await _bankRepositorybank.GetByIdAsync(Id);
                return _mapper.Map<BankDto>(bank);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ServiceResult> Create(BankDto bankDto)
        {
            try
            {
              
                var bank = _mapper.Map<Bank>(bankDto);
                return await _bankRepositorybank.AddAsync(bank);
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
                var ExistBank = await _bankRepositorybank.Entities.AnyAsync(d => d.Id == Id);
                if (ExistBank)
                {
                    var bank = _mapper.Map<Bank>(new BankDto { Id = Id });
                    return await _bankRepositorybank.DeleteAsync(bank);
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

        public async Task<ServiceResult> Update(BankDto bankDto)
        {
            try
            {
                var bank = _mapper.Map<Bank>(bankDto);
                return await _bankRepositorybank.UpdateAsync(bank);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }
        }

    }
}
