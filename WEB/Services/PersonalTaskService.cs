using DATABASE.Entities;
using DATABASE.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.DTOs.PersonalTask;
using WEB.Helpers;

namespace WEB.Services
{
    public class PersonalTaskService : IPersonalTaskService
    {
        private readonly IPersonalTaskRepository _personalTaskRepo;

        public PersonalTaskService(IPersonalTaskRepository personalTaskRepo)
        {
            _personalTaskRepo = personalTaskRepo;
        }

        #region ChangeState()
        public async Task ChangeState(int id)
        {
            try
            {
                var personalTask = await _personalTaskRepo
                    .FindByCondition(x => x.Id == id)
                    .SingleAsync();

                personalTask.IsDone = !personalTask.IsDone;

                _personalTaskRepo.Update(personalTask);
                await _personalTaskRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        }
        #endregion

        #region Create()
        public async Task Create(string content)
        {
            try
            {
                var model = new PersonalTask();
                model.Content = content;

                _personalTaskRepo.Create(model);
                await _personalTaskRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        }
        #endregion

        #region Delete()
        public async Task Delete(int id)
        {
            try
            {
                var entity = await _personalTaskRepo
                    .FindByCondition(x => x.Id == id)
                    .SingleAsync();

                _personalTaskRepo.Delete(entity);
                await _personalTaskRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        } 
        #endregion

        #region GetList()
        public async Task<List<PersonalTaskDto>> GetList()
        {
            try
            {
                return await _personalTaskRepo
                    .GetQuery()
                    .AsQueryable()
                    .Select(x => new PersonalTaskDto
                    {
                        Id = x.Id,
                        Content = x.Content,
                        IsDone = x.IsDone
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                ErrorLog.Log(ex);
                throw;
            }
        } 
        #endregion
    }
}
