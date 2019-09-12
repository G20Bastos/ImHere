using LysisBI.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LysisBI.Models
{
    [Table("usuario")]
    public class usuario
    {
        [Key]
        public int id_usuario { get; set; }

        public string nome_usuario { get; set; }

        public string senha { get; set; }

        public int tipo_usuario { get; set; }

        public int id_professor { get; set; }

        public int id_aluno { get; set; }



    }
}