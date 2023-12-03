﻿#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Entities
{
    public class MoviesGenre
    {

        [Key]
        [Column(Order = 0)]
        public int MovieId{ get; set; }

        public Movie Movie { get; set; }

        [Key] 
        [Column(Order = 1)]
        public int GenreId { get; set; }

      
        public Genre Genre { get; set; }

    }
}
