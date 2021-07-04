using DATABASE.Entities;
using DATABASE.Enums;
using DATABASE.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.DTOs.Teacher;

namespace WEB.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepo;
        private readonly IGroupService _groupService;

        public TeacherService(
            ITeacherRepository teacherRepo,
            IGroupService groupService)
        {
            _teacherRepo = teacherRepo;
            _groupService = groupService;
        }

        public async Task<List<TeacherDto>> GetList()
        {
            try
            {
                var result = new List<TeacherDto>();

                var list = await _teacherRepo
                    .GetQuery()
                    .AsQueryable()
                    .ToListAsync();

                foreach (var item in list)
                {
                    result.Add(await GetModel(item));
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Create(TeacherCreateDto form)
        {
            try
            {
                var model = new Teacher();
                model.FirstName = form.FirstName;
                model.LastName = form.LastName;
                model.Email = form.Email;
                model.PhoneNumber = form.PhoneNumber;
                model.City = form.City;
                model.PostCode = form.PostCode;
                model.Street = form.Street;
                model.Level = form.Level;
                model.Salary = form.Salary;

                _teacherRepo.Create(model);
                await _teacherRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(TeacherEditDto form)
        {
            try
            {
                var model = await _teacherRepo
                    .FindByCondition(x => x.Id == form.Id)
                    .SingleAsync();

                model.FirstName = form.FirstName;
                model.LastName = form.LastName;
                model.Email = form.Email;
                model.PhoneNumber = form.PhoneNumber;
                model.City = form.City;
                model.PostCode = form.PostCode;
                model.Street = form.Street;
                model.Level = form.Level;
                model.Salary = form.Salary;

                _teacherRepo.Update(model);
                await _teacherRepo.SaveChangesAsync();
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
                var entity = await _teacherRepo
                    .FindByCondition(x => x.Id == id)
                    .SingleAsync();

                _teacherRepo.Delete(entity);
                await _teacherRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<TeacherDto> GetModel(Teacher entity)
        {
            var model = new TeacherDto();
            model.Id = entity.Id;
            model.FullName = $"{entity.FirstName} {entity.LastName}";
            model.Email = entity.Email;
            model.PhoneNumber = entity.PhoneNumber;
            model.Level = entity.Level.GetName();
            model.Salary = entity.Salary;
            model.Groups = await _groupService.GetListOfNamesByTeacherId(entity.Id);

            if (!model.Groups.Any())
            {
                model.Groups.Add("Brak");
            }

            return model;
        }

        public async Task<List<SelectListItem>> GetOptions()
        {
            try
            {
                return await _teacherRepo
                    .GetQuery()
                    .Select(x => new SelectListItem($"{x.FirstName} {x.LastName}", x.Id.ToString()))
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TeacherEditDto> GetByIdForFrom(int id)
        {
            try
            {
                return await _teacherRepo
                    .FindByCondition(x => x.Id == id)
                    .Select(x => new TeacherEditDto
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber,
                        City = x.City,
                        PostCode = x.PostCode,
                        Street = x.Street,
                        Salary = x.Salary,
                        Level = x.Level
                    })
                    .SingleAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
