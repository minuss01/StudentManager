using DATABASE.Entities;
using DATABASE.Enums;
using DATABASE.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.DTOs.Student;

namespace WEB.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;

        public StudentService(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
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
                throw ex;
            }
        }

        public async Task GetById(int id)
        {
            throw new NotImplementedException();
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
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
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
                throw ex;
            }
        }
    }
}
