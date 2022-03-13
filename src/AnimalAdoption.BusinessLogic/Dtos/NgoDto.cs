using System;
using System.Collections.Generic;

namespace AnimalAdoption.BusinessLogic.Dtos
{
    public class NgoDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public virtual ICollection<AnimalDto> Animal { get; set; }
    }
}
