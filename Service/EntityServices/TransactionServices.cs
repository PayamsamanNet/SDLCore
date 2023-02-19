using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class TransactionServices
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionServices(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionDto>> GetAll()
        {
            try
            {
                var transaction = await _transactionRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<TransactionDto>>(transaction);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<TransactionDto> GetById(Guid Id)
        {
            try
            {
                var transaction = await _transactionRepository.GetByIdAsync(Id);
                return _mapper.Map<TransactionDto>(transaction);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(TransactionDto transactionDto)
        {
            try
            {
                
                var transaction = _mapper.Map<Transaction>(transactionDto);
                return await _transactionRepository.AddAsync(transaction);
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
                var ExistTransaction = await _transactionRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistTransaction)
                {
                    var transaction = _mapper.Map<Transaction>(new TransactionDto { Id = Id });
                    return await _transactionRepository.DeleteAsync(transaction);
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

        public async Task<ServiceResult> Update(TransactionDto transactionDto)
        {
            try
            {
                var transaction = _mapper.Map<Transaction>(transactionDto);
                return await _transactionRepository.UpdateAsync(transaction);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError,null);
            }
        }
    }
}
