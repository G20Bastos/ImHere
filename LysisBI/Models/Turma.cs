using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LysisBI.Models
{

    [Table("turma")]
    public class Turma
    {

        [Key]
        public int id_turma { get; set; }

        public string dsc_turma { get; set; }
    }
}