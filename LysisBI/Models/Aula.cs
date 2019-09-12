using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LysisBI.Models
{
    [Table("aula")]
    public class Aula
    {
        [Key]
        public int id_aula { get; set; }

        public int id_professor { get; set; }

        public int id_turma { get; set; }

        public string turno { get; set; }

        public string disciplina { get; set; }

        public string token { get; set; }

        
    }
}