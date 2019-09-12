using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LysisBI.Models
{

    [Table("professor")]
    public class Professor
    {

        [Key]
        public int id_professor { get; set; }

        public string nome_professor { get; set; }
    }
}