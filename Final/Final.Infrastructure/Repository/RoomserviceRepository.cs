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
    public class RoomserviceRepository : IRoomserviceRepository
    {
        private readonly FinalDbContext _dbContext;
        public RoomserviceRepository(FinalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Roomservice> AddAsync(Roomservice entity)
        {
            _dbContext.Set<Roomservice>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Roomservice entity)
        {
            _dbContext.Set<Roomservice>().Remove(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<Roomservice> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<Roomservice>().FindAsync(Id);
        }

        public  Roomservice GetEntityById(int Id)
        {
            return  _dbContext.Set<Roomservice>().Find(Id);
        }

        public async Task<IEnumerable<Roomservice>> GetRoomservicesByRoomNo(int RoomNo)
        {
            //var RoomservicesByRoomNo = await
            // _dbContext.Roomservices
            //.Where(g => g.Id == RoomNo)
            ////.SelectMany(g => new Roomservice { Id = g.Id,RoomNo = g.RoomNo, SDesc = g.SDesc, Amount = g.Amount, ServiceDate = g.ServiceDate})
            //.ToListAsync();

            var RoomservicesByRoomNo = await
             _dbContext.Rooms.Include(g=>g.Roomservices)
             .Where(g => g.Id == RoomNo)
             .SelectMany(g=>g.Roomservices)
            //.SelectMany(g => new Roomservice { Id = g.Id,RoomNo = g.RoomNo, SDesc = g.SDesc, Amount = g.Amount, ServiceDate = g.ServiceDate})
            .ToListAsync();

            return RoomservicesByRoomNo;

        }

        public async Task<IEnumerable<Roomservice>> ListAllAsync()
        {
            return await _dbContext.Set<Roomservice>().ToListAsync();
        }

        public async Task<IEnumerable<Roomservice>> ListAsync(Expression<Func<Roomservice, bool>> filter)
        {
            return await _dbContext.Set<Roomservice>().ToListAsync();
        }

        public async Task<Roomservice> UpdateAsync(Roomservice entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Roomservice> UpdateRoomservice(int id, RoomserviceCreateRequestModel roomservice)
        {
            var local = _dbContext.Set<Roomservice>().Local.FirstOrDefault(c => c.Id == id);
            if (local != null) _dbContext.Entry(local).State = EntityState.Detached;
            var entity = new Roomservice
            {
                Id = id,
                RoomNo = roomservice.RoomNo,
                SDesc = roomservice.SDesc,
                Amount = roomservice.Amount
            };
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
