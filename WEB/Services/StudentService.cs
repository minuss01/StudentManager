using DATABASE.Entities;
using DATABASE.Enums;
using DATABASE.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.DTOs.Student;
using WEB.Helpers;

namespace WEB.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IGroupService _groupService;

        public StudentService(
            IStudentRepository studentRepo,
            IGroupService groupService)
        {
            _studentRepo = studentRepo;
            _groupService = groupService;
        }

        public async Task<List<StudentDto>> GetList()
        {
            try
            {
                return await _studentRepo
                    .GetQuery()
                    .Include(x => x.Group)
                    .Select(x => GetModel(x))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw ex;
            }
        }

        public async Task Create(StudentCreateDto form)
        {
            try
            {
                var model = new Student();
                model.FirstName = form.FirstName;
                model.LastName = form.LastName;
                model.Email = form.Email;
                model.PhoneNumber = form.PhoneNumber;
                model.City = form.City;
                model.PostCode = form.PostCode;
                model.Street = form.Street;
                model.Level = form.Level;
                model.GroupId = form.GroupId;

                _studentRepo.Create(model);
                await _studentRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw ex;
            }
        }

        public async Task Update(StudentEditDto form)
        {
            try
            {
                var entity = await _studentRepo
                    .FindByCondition(x => x.Id == form.Id)
                    .SingleAsync();

                entity.FirstName = form.FirstName;
                entity.LastName = form.LastName;
                entity.Email = form.Email;
                entity.PhoneNumber = form.PhoneNumber;
                entity.City = form.City;
                entity.PostCode = form.PostCode;
                entity.Street = form.Street;
                entity.Level = form.Level;
                entity.GroupId = form.GroupId;

                _studentRepo.Update(entity);
                await _studentRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var entity = await _studentRepo
                    .FindByCondition(x => x.Id == id)
                    .SingleAsync();

                _studentRepo.Delete(entity);
                await _studentRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw ex;
            }
        }

        private static StudentDto GetModel(Student entity)
        {
            return new StudentDto
            {
                Id = entity.Id,
                FullName = $"{entity.FirstName} {entity.LastName}",
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Level = entity.Level.GetName(),
                GroupName = entity.Group.Name,
            };
        }

        public async Task<StudentEditDto> GetByIdForFrom(int id)
        {
            try
            {
                return await _studentRepo
                    .FindByCondition(x => x.Id == id)
                    .Select(x => new StudentEditDto
                    {
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email,
                        PhoneNumber = x.PhoneNumber,
                        City = x.City,
                        PostCode = x.PostCode,
                        Street = x.Street,
                        Level = x.Level
                    })
                    .SingleAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        }

        public async Task CreateRange(List<StudentFromFileDto> list)
        {
            try
            {

                var plugGroupId = await _groupService.CreatePlugIfNotExists();

                foreach (var item in list)
                {
                    var model = new Student();
                    model.FirstName = item.FirstName;
                    model.LastName = item.LastName;
                    model.Email = item.Email;
                    model.PhoneNumber = item.PhoneNumber;
                    model.City = item.City;
                    model.PostCode = item.PostCode;
                    model.Street = item.Street;
                    model.Level = item.Level;

                    if (await _groupService.GroupExists(item.GroupId))
                    {
                        model.GroupId = item.GroupId;
                    }
                    else
                    {
                        model.GroupId = plugGroupId;
                    }

                    _studentRepo.Create(model);
                }
                
                await _studentRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw ex;
            }
        }
    }
}
