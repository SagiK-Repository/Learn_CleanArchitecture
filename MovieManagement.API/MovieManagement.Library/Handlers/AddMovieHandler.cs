using MediatR;
using MovieManagement.Library.Data;
using MovieManagement.Library.Models;
using MovieManagement.Library.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Library.Handlers
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, MovieModel>
    {
        private readonly IDataRepository _dataRepository;

        public AddMovieHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public Task<MovieModel> Handle(AddMovieCommand request, CancellationToken cancellationToken)
            => Task.FromResult(_dataRepository.AddMovie(request.model));
    }
}
