using DabClinic.Domain.IService;
using DabClinic.Domain.Models;
using DabClinic.EntityFramework.Context;
using DabClinicRepo.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabClinic.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly DabClinicDbContextFactory _contextFactory;

        //Một class để CRUD cho tất cả các table luôn
        //Domain object được tạo ra để đảm bảo rằng entity nào cũng có ID
        public GenericDataService(DabClinicDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using (DabClinicContext context = _contextFactory.CreateDbContext())
            {
                EntityEntry<T> createdEntity = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (DabClinicContext context = _contextFactory.CreateDbContext())
            {
                T? entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                if (entity != null)
                {
                    context.Set<T>().Remove(entity);
                }
                await context.SaveChangesAsync();

                //TODO: handle error
                return true;
            }
        }

        public async Task<T> Get(int id)
        {
            using (DabClinicContext context = _contextFactory.CreateDbContext())
            {
                T? entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity!;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (DabClinicContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            //id: id to update
            //entity: new value
            using (DabClinicContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                //TODO: handle error
                return entity;
            }
        }
    }
}
