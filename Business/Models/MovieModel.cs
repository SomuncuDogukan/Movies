#nullable disable
using Data_Access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class MovieModel
    {
        public int id { get; set; }

        public string Name { get; set; }

        public short? Year { get; set; }

        public double Revenue { get; set; }

        public int? DirectorId { get; set; }

        public string directorOutput { get; set; }


    }
}

