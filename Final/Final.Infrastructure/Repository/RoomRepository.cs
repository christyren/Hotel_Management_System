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
    public class RoomRepository : IRoomRepository
    {
        private readonly FinalDbContext _dbContext;
        public RoomRepository(FinalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Room> AddAsync(Room entity)
        {
            _dbContext.Set<Room>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Room entity)
        {
            _dbContext.Set<Room>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Room> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<Room>().FindAsync(Id);
        }

        public Room GetEntityById(int Id)
        {
            return _dbContext.Set<Room>().Find(Id);
        }



        public async Task<IEnumerable<Room>> ListAllAsync()
        {
            return await _dbContext.Set<Room>().ToListAsync();
        }

        public async Task<IEnumerable<Room>> ListAsync(Expression<Func<Room, bool>> filter)
        {
            return await _dbContext.Set<Room>().ToListAsync();
        }

        public async Task<Room> UpdateAsync(Room entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Room> UpdateRoom(int id, RoomCreateRequestModel room)
        {
            var local = _dbContext.Set<Room>().Local.FirstOrDefault(c => c.Id == id);
            if (local != null) _dbContext.Entry(local).State = EntityState.Detached;
            var entity = new Room
            {
                Id = id,
                RTCode = room.RTCode,
                Status = room.Status
            };
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
