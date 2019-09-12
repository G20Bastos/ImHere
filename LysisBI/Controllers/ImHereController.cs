using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.PowerBI.Api.V2;
using Microsoft.PowerBI.Api.V2.Models;
using Microsoft.Rest;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using LysisBI.Models.Services;
using System;

namespace LysisBI.Controllers
{
    public class ImHereController : Controller
    {
      


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(UsuarioServices usuario)
        {
            if (!usuario.validaAcesso())
            {
                ViewBag.msgErro = "Usuário e/ou Senha incorretos!";
                return View(usuario);

            }
            else

                 if (usuario.TipoUsuario == 0)
            {
                Session["Usuario"] = usuario.NomeUsuario;
                Session["IdProfessor"] = usuario.IdProfessor;
                
                return RedirectToAction("SelecaoTurma");

            }
            else if (usuario.TipoUsuario == 1)
            {

                Session["Usuario"] = usuario.NomeUsuario;
                Session["IdAluno"] = usuario.IdAluno;

                return RedirectToAction("AmbienteAluno");

            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult SelecaoTurma()

        {
            AulaServices aula = new AulaServices();
            aula.Id_professor = (int)(Session["IdProfessor"]);
            aula.ListaDeAulas = aula.listaAula();
            return View(aula);
        }

        public ActionResult AmbienteAluno()

        {
            return View();
        }

        [HttpPost]
        public ActionResult AmbienteAluno(AulaServices aula)

        {
            
            aula.listarDadosAula(aula.Token);
            Session["IdAula"]= aula.Id_aula;
            Session["Disciplina"] = aula.Disciplina;
            Session["Turma"] = aula.Dsc_turma;
            Session["Turno"] = aula.Turno;
            Session["Professor"] = aula.Nome_professor;
            Session["Token"] = aula.Token;


            AlunoServices aluno = new AlunoServices();
            aluno.obterDadosAluno((int)(Session["IdAluno"]));
            Session["NomeAluno"] = aluno.NomeAluno;
            Session["Matricula"] = aluno.MatriculaAluno;
            return RedirectToAction("ConfirmacaoDados");
        }

        public ActionResult ConfirmacaoDados()

        {

            return View();
        }


        [HttpPost]
        public ActionResult EfetivarPresenca()

        {
            
            FrequenciaServices frequencia = new FrequenciaServices();

            
            frequencia.IdAula = (int)(Session["IdAula"]);
            frequencia.IdAluno = (int)(Session["IdAluno"]);
            frequencia.MatriculaAluno = (string)(Session["Matricula"]); ;
            frequencia.NomeAluno = (string)(Session["NomeAluno"]); ;
            frequencia.DataHoraRegistro = DateTime.Now;
            frequencia.Presenca = true;
            frequencia.TokenUtilizado = (string)(Session["Token"]);

            frequencia.inserirPresenca();


            return RedirectToAction("Exito");
        }

        
        public ActionResult Exito()

        {
            return View();

        }

        [HttpPost]
        public ActionResult Logout()

        {
            Session["NomeAluno"] = null;
            Session["Matricula"] = null;
            Session["IdAula"] = null;
            Session["Disciplina"] = null;
            Session["Turma"] = null;
            Session["Turno"] = null;
            Session["Professor"] = null;
            Session["Token"] = null;
            Session["Usuario"] = null;
            Session["IdAluno"] = null;
            Session["IdProfessor"] = null;

            return RedirectToAction("Login");

        }



    }

    }


