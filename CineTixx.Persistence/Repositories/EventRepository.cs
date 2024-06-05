using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using MongoDB.Driver;

namespace CineTixx.Persistence.Repositories
{
    public sealed class EventRepository : IEventRepository
    {
        private readonly IMongoCollection<Event> _eventCollection;

        public EventRepository(IMongoDatabase database)
        {
            _eventCollection = database.GetCollection<Event>("Events");
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _eventCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Event> GetByIdAsync(Guid id)
        {
            return await _eventCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Event events)
        {
            await _eventCollection.InsertOneAsync(events);
        }

        public async Task UpdateAsync(Event events)
        {
            await _eventCollection.ReplaceOneAsync(c => c.Id == events.Id, events);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _eventCollection.DeleteOneAsync(c => c.Id == id);
        }
    }
}