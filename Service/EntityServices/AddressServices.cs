using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class AddressServices
    {
        private readonly IAddressRepository _addressRepositoty;
        private readonly IMapper _mapper;


        public AddressServices(IAddressRepository addressRepositoty, IMapper mapper)
        {
            _addressRepositoty = addressRepositoty;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AddressDto>> GetAll()
        {
            try
            {
                var addresses = await _addressRepositoty.Entities.ToListAsync();
                return _mapper.Map<List<AddressDto>>(addresses);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public async Task<AddressDto> GetById(Guid Id)
        {
            try
            {
                var address = await _addressRepositoty.GetByIdAsync(Id);

                return _mapper.Map<AddressDto>(address);
            }
            catch (Exception)
            {

                return null;
            }

        }
        public async Task<ServiceResult> Create(AddressDto addressDto)
        {
            try
            {
                 addressDto.Id= Guid.NewGuid();
                var address = _mapper.Map<Address>(addressDto);

                return await _addressRepositoty.AddAsync(address);

            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError);
            }

        }
        public async Task<ServiceResult> Update(AddressDto addressDto)
        {
            try
            {
                var address = _mapper.Map<Address>(addressDto);
                return await _addressRepositoty.UpdateAsync(address);

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
                var ExistUser = await _addressRepositoty.Table.AnyAsync(x => x.Id == Id);
                if (ExistUser)
                {
                    var address = _mapper.Map<Address>(new AddressDto { Id = Id });
                    return await _addressRepositoty.DeleteAsync(address);
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



    }
}
