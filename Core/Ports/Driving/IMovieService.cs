using CineTixx.Core.DTOs;

namespace CineTixx.Core.Ports.Driving
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
        Task<MovieDto> GetMovieAsync(Guid id);
        Task AddMovieAsync(MovieDto movieDto);
        Task UpdateMovieAsync(MovieDto movieDto);
        Task DeleteMovieAsync(Guid id);
    }
}
