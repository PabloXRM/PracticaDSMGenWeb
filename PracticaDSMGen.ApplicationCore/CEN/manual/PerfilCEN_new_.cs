
using System;
using System.Text;
using System.Collections.Generic;
using PracticaDSMGen.ApplicationCore.Exceptions;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


/*PROTECTED REGION ID(usingPracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Perfil_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
public partial class PerfilCEN
{
public int New_ (string p_usuario)
{
        /*PROTECTED REGION ID(PracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Perfil_new__customized) START*/

        PerfilEN perfilEN = null;

        int oid;

        //Initialized PerfilEN
        perfilEN = new PerfilEN ();

        if (p_usuario != null) {
                perfilEN.Usuario = new PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN ();
                perfilEN.Usuario.Email = p_usuario;
        }

        //Call to PerfilRepository

        oid = _IPerfilRepository.New_ (perfilEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
