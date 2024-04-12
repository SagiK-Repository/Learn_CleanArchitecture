using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure
{
    public interface IMovieRentalDBContext
    {
        DbSet<Movie> Movies { get; set; }
    }
}
