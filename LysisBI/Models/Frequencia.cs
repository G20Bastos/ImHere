using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LysisBI.Models
{
    [Table("frequencia")]
    public class Frequencia
    {
        [Key]
        public int id_frequencia { get; set; }

        public int id_aula { get; set; }

        public int id_aluno { get; set; }

        public string matricula_aluno { get; set; }

        public string nome_aluno { get; set; }

        public DateTime datahora_registro { get; set; }

        public bool presenca { get; set; }

        public string token_utilizado { get; set; }
    }
}