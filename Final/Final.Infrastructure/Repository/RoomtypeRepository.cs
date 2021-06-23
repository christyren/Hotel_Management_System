using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Final.ApplicationCore.Entitity;
using Final.ApplicationCore.Model.Request;
using Final.ApplicationCore.RepositoryInterface;
using Final.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Final.Infrastructure.Repository
{
    public class RoomtypeRepository : IRoomtypeRepository
    {
        private readonly FinalDbContext _dbContext;
        public RoomtypeRepository(FinalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Roomtype> AddAsync(Roomtype entity)
        {
            _dbContext.Set<Roomtype>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Roomtype entity)
        {
            _dbContext.Set<Roomtype>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Roomtype> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<Roomtype>().FindAsync(Id);
        }

        public Roomtype GetEntityById(int Id)
        {
            return _dbContext.Set<Roomtype>().Find(Id);
        }

        public async Task<IEnumerable<Roomtype>> ListAllAsync()
        {
            return await _dbContext.Set<Roomtype>().ToListAsync();
        }

        public async Task<IEnumerable<Roomtype>> ListAsync(Expression<Func<Roomtype, bool>> filter)
        {
            return await _dbContext.Set<Roomtype>().ToListAsync();
        }

        public async Task<Roomtype> UpdateAsync(Roomtype entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Roomtype> UpdateRoomtype(int id, RoomtypeCreateRequestModel roomtype)
        {
            var local = _dbContext.Set<Roomtype>().Local.FirstOrDefault(c => c.Id == id);
            if (local != null) _dbContext.Entry(local).State = EntityState.Detached;
            var entity = new Roomtype
            {
                Id = id,
                RTDesc = roomtype.RTDesc,
                Rent = roomtype.Rent
            };
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
