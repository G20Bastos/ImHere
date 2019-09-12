using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LysisBI.Models
{

    [Table("aluno")]
    public class Aluno
    {
        [Key]
        public int id_aluno { get; set; }

        public string matricula_aluno { get; set; }

        public string nome_aluno { get; set; }
    }
}