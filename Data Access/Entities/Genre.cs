#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Entities
{
    public class Genre:Record
    {

        public string Name { get; set; }

        public List<MoviesGenre> MoviesGenres { get; set; }
    }
}
