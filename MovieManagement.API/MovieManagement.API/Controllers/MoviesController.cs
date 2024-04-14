using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieManagement.Library.Models;
using MovieManagement.Library.Queries;

namespace MovieManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Get: api/<MoviesController>
        [HttpGet]
        public async Task<List<MovieModel>> Get()
            => await _mediator.Send(new GetMovieListQuery());

        [HttpGet("{id}")]
        public async Task<MovieModel> Get(int id)
            => await _mediator.Send(new GetMovieByIdQuery(id));

        [HttpPost]
        public async Task<MovieModel> Post(MovieModel movieModel)
            => await _mediator.Send(new AddMovieCommand(movieModel));
            
    }
}
