using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class FemaleCharactersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Characteristic { get; set; }
        public List<MaleCharacter> Relationships { get; set; }
        public int BookId { get; set; }
    }
}
