#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Entities
{
    public class Movie:Record
    {
        public string Name { get; set; }

        public short? Year { get; set; }

        public double Revenue { get; set; }

        public int DirectorId { get; set; }

        public Director Director { get; set; }

        public List<MoviesGenre> MovieGenres { get; set; }
    }
}
