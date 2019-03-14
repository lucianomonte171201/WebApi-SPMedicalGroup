using Microsoft.EntityFrameworkCore;
using Senai.SpMedicalGroup.Domains;
using Senai.SpMedicalGroup.Interfaces;
using Senai.SpMedicalGroup.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Atualizar(Usuarios usuario)
        {
            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                ctx.Usuarios.Update(usuario);
                ctx.SaveChanges();
            }
        }

        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                return ctx.Usuarios.Include(x => x.IdTipoNavigation).FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
            }
        }

        public void Cadastrar(Usuarios usuario)
        {
            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(Usuarios usuario)
        {
            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                ctx.Usuarios.Remove(usuario);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> ListarUsuarios()
        {
            using (SpMedicalGroupContext ctx = new SpMedicalGroupContext())
            {
                return ctx.Usuarios.ToList();
            }
            
        }
    }
}
