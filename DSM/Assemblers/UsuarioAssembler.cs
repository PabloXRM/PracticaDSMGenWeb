using DSM.Models;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using System.Collections.Generic;
using System;

namespace DSM.Assemblers
{
    public class UsuarioAssembler
    {
        public UsuarioViewModel ConvertirENToViewModel(UsuarioEN en)
        {
            UsuarioViewModel usu = new UsuarioViewModel();
            usu.email = en.Email;
            usu.Nombre = en.Nombre;
            usu.Direccion = en.Direccion;
            usu.FechaNacimiento = (DateTime)en.FechaNacimiento;
            usu.CodPostal = en.CodPostal;
            return usu;
        }

        public IList<UsuarioViewModel> ConvertirListENToViewModel(IList<UsuarioEN> ens)
        {
            IList<UsuarioViewModel> arts = new List<UsuarioViewModel>();
            foreach (UsuarioEN en in ens)
            {
                arts.Add(ConvertirENToViewModel(en));
            }
            return arts;
        }


    }
}
