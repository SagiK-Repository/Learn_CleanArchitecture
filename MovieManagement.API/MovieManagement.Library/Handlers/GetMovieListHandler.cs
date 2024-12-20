﻿using MediatR;
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
    public class GetMovieListHandler : IRequestHandler<GetMovieListQuery, List<MovieModel>>
    {
        private readonly IDataRepository _dataRepository;
        public GetMovieListHandler(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public Task<List<MovieModel>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
            => Task.FromResult(_dataRepository.GetMovies());
    }
}
