using DATABASE.Entities;
using DATABASE.Enums;
using DATABASE.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.DTOs.Group;

namespace WEB.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;

        public GroupService(
            IGroupRepository groupRepo)
        {
            _groupRepo = groupRepo;
        }

        public async Task<List<SelectListItem>> GetOptions()
        {
            try
            {
                return await _groupRepo
                    .GetQuery()
                    .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GroupDto>> GetList()
        {
            try
            {
                return await _groupRepo
                        .GetQuery()
                        .Include(x => x.Teacher)
                        .Select(x => new GroupDto
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Level = x.Level.GetName(),
                            TeacherName = $"{x.Teacher.FirstName} {x.Teacher.LastName}"
                        })
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Create(GroupCreateDto form)
        {
            try
            {
                var model = new Group();
                model.Name = form.Name;
                model.Level = form.Level;
                model.TeacherId = form.TeacherId;

                _groupRepo.Create(model);
                await _groupRepo.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<string>> GetListOfNamesByTeacherId(int teacherId)
        {
            try
            {
                return await _groupRepo
                        .FindByCondition(x => x.TeacherId == teacherId)
                        .Select(x => x.Name)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(GroupEditDto form)
        {
            try
            {
                var model = await _groupRepo
                    .FindByCondition(x => x.Id == form.Id)
                    .SingleAsync();

                model.Name = form.Name;
                model.TeacherId = form.TeacherId;
                model.Level = form.Level;

                _groupRepo.Update(model);
                await _groupRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GroupEditDto> GetByIdForFrom(int id)
        {
            try
            {
                var entity =  await _groupRepo
                    .FindByCondition(x => x.Id == id)
                    .SingleAsync();

                var model = new GroupEditDto();
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Level = entity.Level;
                model.TeacherId = entity.TeacherId;

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var entity = await _groupRepo
                    .FindByCondition(x => x.Id == id)
                    .SingleAsync();

                _groupRepo.Delete(entity);
                await _groupRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
