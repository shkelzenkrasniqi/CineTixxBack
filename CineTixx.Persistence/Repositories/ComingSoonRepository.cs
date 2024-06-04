
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using MongoDB.Driver;

namespace CineTixx.Persistence.Repositories
{
    public sealed class ComingSoonRepository : IComingSoonRepository
    {
        private readonly IMongoCollection<ComingSoon> _comingSoonCollection;

        public ComingSoonRepository(IMongoDatabase database)
        {
            _comingSoonCollection = database.GetCollection<ComingSoon>("ComingSoon");
        }

        public async Task<IEnumerable<ComingSoon>> GetAllAsync()
        {
            return await _comingSoonCollection.Find(_ => true).ToListAsync();
        }

        public async Task<ComingSoon> GetByIdAsync(Guid id)
        {
            return await _comingSoonCollection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(ComingSoon comingSoon)
        {
            await _comingSoonCollection.InsertOneAsync(comingSoon);
        }

        public async Task UpdateAsync(ComingSoon comingSoon)
        {
            await _comingSoonCollection.ReplaceOneAsync(c => c.Id == comingSoon.Id, comingSoon);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _comingSoonCollection.DeleteOneAsync(c => c.Id == id);
        }
    }
}