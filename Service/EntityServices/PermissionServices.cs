using AutoMapper;
using Common.ApiResult;
using Core.Entities;
using Data.Dto;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.EntityServices
{

    public class PermissionServices
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IMapper _mapper;

        public PermissionServices(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PermissionDto>> GetAll()
        {
            try
            {
                var permission = await _permissionRepository.Entities.ToArrayAsync();
                return _mapper.Map<List<PermissionDto>>(permission);

            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<InsuranceDto> GetById(Guid Id)
        {
            try
            {
                var permission = await _permissionRepository.GetByIdAsync(Id);
                return _mapper.Map<InsuranceDto>(permission);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<ServiceResult> Create(PermissionDto permissionDto)
        {
            try
            {

                var permission = _mapper.Map<Permission>(permissionDto);
               
                return await _permissionRepository.AddAsync(permission);
            }
            catch (Exception)
            {
                return new ServiceResult(ResponseStatus.ServerError, null);
            }

        }

        public async Task<ServiceResult> Delete(Guid Id)
        {
            try
            {
                var ExistPermission = await _permissionRepository.Entities.AnyAsync(d => d.Id == Id);
                if (ExistPermission)
                {
                    var permission = _mapper.Map<Permission>(new PermissionDto { Id = Id });
                    return await _permissionRepository.DeleteAsync(permission);
                }
                else
                {
                    return new ServiceResult(ResponseStatus.NotFound, null);
                }
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError, null);
            }
        }

        public async Task<ServiceResult> Update(PermissionDto permissionDto)
        {
            try
            {
                var permission = _mapper.Map<Permission>(permissionDto);
                return await _permissionRepository.UpdateAsync(permission);
            }
            catch (Exception)
            {

                return new ServiceResult(ResponseStatus.ServerError, null);
            }
        }
    }
}
