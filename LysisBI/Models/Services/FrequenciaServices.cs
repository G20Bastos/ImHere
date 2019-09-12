using LysisBI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LysisBI.Models.Services
{
    public class FrequenciaServices
    {
        public int IdAula { get; set; }

        public int IdAluno { get; set; }

        public string MatriculaAluno { get; set; }

        public string NomeAluno { get; set; }

        public DateTime DataHoraRegistro { get; set; }

        public bool Presenca { get; set; }

        public string TokenUtilizado { get; set; }


        DatabaseContext db = new DatabaseContext();
        
        

        public void inserirPresenca()
        {
            Frequencia frequencia = new Frequencia();
            
             frequencia.id_frequencia = 2;
            frequencia.id_aula = IdAula;
            frequencia.id_aluno = IdAluno;
            frequencia.matricula_aluno = MatriculaAluno;
            frequencia.nome_aluno = NomeAluno;
            frequencia.datahora_registro = DataHoraRegistro;
            frequencia.presenca = Presenca;
            frequencia.token_utilizado = TokenUtilizado;
            db.Frequencia.Add(frequencia);
            db.SaveChanges();
            
            
            


        }
    }
}