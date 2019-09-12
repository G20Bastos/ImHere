using LysisBI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LysisBI.Models.Services
{
    public class UsuarioServices
    {
        public string UsuarioDigitado { get; set; }

        public string SenhaDigitada { get; set; }

        public int Id { get; set; }

        public int TipoUsuario { get; set; }

        public string NomeUsuario { get; set; }

        public int IdProfessor { get; set; }

        public int IdAluno { get; set; }




        // -- INICIO DA SESSÃO DE MÉTODOS

        DatabaseContext db = new DatabaseContext();

        public bool validaAcesso()
        {

            var usuarioBase = db.Usuario.Where(m => m.nome_usuario == UsuarioDigitado && m.senha == SenhaDigitada).FirstOrDefault();

            try{
                if (usuarioBase != null && usuarioBase.tipo_usuario == 0)
                {
                    NomeUsuario = usuarioBase.nome_usuario;
                    TipoUsuario = 0;
                    IdProfessor = usuarioBase.id_professor;
                    
                    return true;
                } 
                else if (usuarioBase != null && usuarioBase.tipo_usuario == 1)
                {
                    NomeUsuario = usuarioBase.nome_usuario;
                    TipoUsuario = 1;
                    IdAluno = usuarioBase.id_aluno;
                    return true;
                }
                return false;
                }
            catch
            {
                return false;
            }

            
        }



    }
}