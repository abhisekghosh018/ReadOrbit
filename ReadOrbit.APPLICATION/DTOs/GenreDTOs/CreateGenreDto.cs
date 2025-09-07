using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadOrbit.APPLICATION.DTOs.GenreDTOs
{
    public class CreateGenreDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        public string Name { get; set; }
    }    
}
