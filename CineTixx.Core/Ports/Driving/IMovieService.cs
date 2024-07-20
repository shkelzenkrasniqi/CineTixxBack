using CineTixx.Core.DTOs;
using Microsoft.AspNetCore.Http;

namespace CineTixx.Core.Ports.Driving
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
        Task<MovieDto> GetMovieAsync(Guid id);
        Task<MovieDto> AddMovieAsync(MovieDto movieDto, List<IFormFile> photos);
        Task UpdateMovieAsync(MovieDto movieDto);
        Task DeleteMovieAsync(Guid id);
    }
}
