using Senai.SpMedicalGroup.Domains;
using Senai.SpMedicalGroup.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedicalGroup.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuarios> ListarUsuarios();

        void Cadastrar(Usuarios usuario);

        void Deletar(Usuarios usuario);

        void Atualizar(Usuarios usuario);

        Usuarios BuscarPorEmailESenha(LoginViewModel login);
    }
}
