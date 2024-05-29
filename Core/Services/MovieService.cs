using AutoMapper;
using CineTixx.Core.DTOs;
using CineTixx.Core.Entities;
using CineTixx.Core.Ports.Driven;
using CineTixx.Core.Ports.Driving;
using Microsoft.AspNetCore.Http;
using System.Data.Entity.Core.Metadata.Edm;

namespace CineTixx.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }
        public async Task<MovieDto> GetMovieAsync(Guid id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return _mapper.Map<MovieDto>(movie);
        }
        public async Task<MovieDto> AddMovieAsync(MovieDto movieDto, List<IFormFile> photos)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await AddPhotosToMovieAsync(movie, photos);

            await _movieRepository.AddAsync(movie);
            return _mapper.Map<MovieDto>(movie);

        }
        public async Task UpdateMovieAsync(MovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            await _movieRepository.UpdateAsync(movie);
        }
        public async Task DeleteMovieAsync(Guid id)
        {
            await _movieRepository.DeleteAsync(id);
        }
        private async Task AddPhotosToMovieAsync(Movie movie, List<IFormFile> photos)
        {
            if (photos != null && photos.Count > 0)
            {
                movie.Photos = new List<MoviePhoto>();

                foreach (var photo in photos)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await photo.CopyToAsync(memoryStream);
                        movie.Photos.Add(new MoviePhoto
                        {
                            PhotoData = memoryStream.ToArray(),
                            ContentType = photo.ContentType
                        });
                    }
                }
            }
        }
    }
}
