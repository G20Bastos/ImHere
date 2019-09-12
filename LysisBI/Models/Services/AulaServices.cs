using LysisBI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LysisBI.Models.Services
{
    public class AulaServices
    {
        public int Id_aula { get; set; }

        public int Id_professor { get; set; }

        public string Nome_professor { get; set; }

        public int Id_turma { get; set; }

        public string Dsc_turma { get; set; }

        public string Turno { get; set; }

        public string Disciplina { get; set; }

        public string Token { get; set; }

        public List<SelectListItem> ListaDeAulas { get; set; }

        public bool Selected { get; set; }

        public List<SelectListItem> listaAula()
        {
            DatabaseContext db = new DatabaseContext();
            var consultaAula = from A in db.Aula


                                   join P in db.Professor
                                   on A.id_professor equals P.id_professor

                                   join T in db.Turma
                                   on A.id_turma equals T.id_turma

                                   where A.id_professor == Id_professor

                                   select new
                                   {

                                       A.id_aula,
                                       A.disciplina,
                                       A.turno,
                                       T.dsc_turma
                                   };

            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (var currentRow in consultaAula.Distinct().OrderBy(c => c.id_aula))
            {
                SelectListItem item = new SelectListItem();
                item.Value = currentRow.id_aula.ToString();
                item.Text = currentRow.disciplina + " | " + currentRow.turno + " | " + currentRow.dsc_turma;

                lst.Add(item);
            }

            return lst;
        }

        public void listarDadosAula(string token)
        {
            DatabaseContext db = new DatabaseContext();
            var consultaAulaPorToken = from A in db.Aula


                               join P in db.Professor
                               on A.id_professor equals P.id_professor

                               join T in db.Turma
                               on A.id_turma equals T.id_turma

                               where A.token == token

                               select new
                               {

                                   A.id_aula,
                                   A.disciplina,
                                   A.turno,
                                   T.dsc_turma,
                                   P.nome_professor
                               };

            if (consultaAulaPorToken.Count() != 0)
            {
                foreach (var currentRow in consultaAulaPorToken.Distinct().OrderBy(c => c.id_aula))
                {
                    Id_aula = currentRow.id_aula;
                    Disciplina = currentRow.disciplina;
                    Turno = currentRow.turno;
                    Dsc_turma = currentRow.dsc_turma;
                    Nome_professor = currentRow.nome_professor;



                }
            }
           
        }
    }
}