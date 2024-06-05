using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Core.Ports.Driving;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineTixx.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventDto>> GetAllEventAsync()
        {
            var eventList = await _eventRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EventDto>>(eventList);
        }

        public async Task<EventDto> GetEventAsync(Guid id)
        {
            var events = await _eventRepository.GetByIdAsync(id);
            return _mapper.Map<EventDto>(events);
        }

        public async Task AddEventAsync(EventDto eventDto)
        {
            var events = _mapper.Map<Event>(eventDto);
            await _eventRepository.AddAsync(events);
        }

        public async Task UpdateEventAsync(EventDto eventDto)
        {
            var events = _mapper.Map<Event>(eventDto);
            await _eventRepository.UpdateAsync(events);
        }

        public async Task DeleteEventAsync(Guid id)
        {
            await _eventRepository.DeleteAsync(id);
        }
    }
}