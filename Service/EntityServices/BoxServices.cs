using AutoMapper;
using Common.ApiResult;
using Common.Pagination;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Service.EntityServices
{
    public class BoxServices
    {
        private readonly IBoxRepository _boxRepository;
        private readonly IMapper _mapper;

        public BoxServices(IBoxRepository boxRepository, IMapper mapper)
        {
            _boxRepository = boxRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BoxDto>> GetAll()
        {
            try
            {
                var box = await _boxRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<BoxDto>>(box);

            }
            catch (Exception)
            {

                return null;
            }
        }


        public async Task<PagedResponse<IEnumerable<BoxDto>>> GetByPgination(PagedResponse<BoxDto> pagedResponse)
        {
            try
            {
                var qurey = _boxRepository.Table.AsQueryable();
                var Total = qurey.Count();
                if (pagedResponse.Data.Number != 0)
                {
                    qurey= qurey.Where(x => x.Number == pagedResponse.Data.Number);
                    qurey.Count();
                }
                if (pagedResponse.Data.RepositoryId != Guid.Empty)
                {
                    qurey = qurey.Where(x => x.RepositoryId == pagedResponse.Data.RepositoryId);
                    qurey.Count();
                }

                


                var Boxes = qurey.OrderBy(s => s.Id).Skip(pagedResponse.StartIndex).Take(pagedResponse.PageSize).ToList();

                var ListBoxes = _mapper.Map<IEnumerable<BoxDto>>(Boxes);
                return new PagedResponse<IEnumerable<BoxDto>>(pagedResponse.PageNumber, Total, ListBoxes);
            }
            catch (Exception)
            {
                return null;
            }
        }



        public async Task<BoxDto> GetById(Guid Id)
        {
            try
            {
                var box = await _boxRepository.GetByIdAsync(Id);
                return _mapper.Map<BoxDto>(box);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(BoxDto boxDto)
        {
            try
            {
            
                var box = _mapper.Map<Box>(boxDto);
                return await _boxRepository.AddAsync(box);
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
                var ExistBox = await _boxRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistBox)
                {
                    var box = _mapper.Map<Box>(new BoxDto { Id = Id });
                    return await _boxRepository.DeleteAsync(box);
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

        public async Task<ServiceResult> Update(BoxDto boxDto)
        {
            try
            {
                var box = _mapper.Map<Box>(boxDto);
                return await _boxRepository.UpdateAsync(box);
            }
            catch (Exception)
            {
                return new ServiceResult(ResponseStatus.ServerError,null);
            }
        }
    }
}
