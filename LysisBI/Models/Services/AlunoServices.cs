using LysisBI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LysisBI.Models.Services
{
    public class AlunoServices
    {
        public string NomeAluno { get; set; }
        
        public string MatriculaAluno { get; set; }

        public void obterDadosAluno(int id_aluno)
        {
            DatabaseContext db = new DatabaseContext();
            var consultaAlunoPorId = from A in db.Aluno


                                      

                                       where A.id_aluno == id_aluno

                                       select new
                                       {

                                           A.nome_aluno,
                                           A.matricula_aluno
                                       };

            if (consultaAlunoPorId.Count() != 0)
            {
                foreach (var currentRow in consultaAlunoPorId.Distinct())
                {
                    NomeAluno = currentRow.nome_aluno;
                    MatriculaAluno = currentRow.matricula_aluno;
                    

                }
            }

        }
    }
}