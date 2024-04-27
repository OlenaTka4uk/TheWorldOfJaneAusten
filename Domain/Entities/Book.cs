﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }

        //Navigation
        //public List<FemaleCharacter> FemailCharacters { get; set; }
        //public List<MaleCharacter> MailCharacters { get; set; }
    }
}
