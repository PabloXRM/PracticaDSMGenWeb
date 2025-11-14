
using System;
using System.Text;
using System.Collections.Generic;
using PracticaDSMGen.ApplicationCore.Exceptions;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


/*PROTECTED REGION ID(usingPracticaDSMGen.ApplicationCore.CEN.PracticaDSM_MetodoPago_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
public partial class MetodoPagoCEN
{
public int New_ (string p_usuario, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TipoPagoEnum p_tipo, bool p_valido)
{
        /*PROTECTED REGION ID(PracticaDSMGen.ApplicationCore.CEN.PracticaDSM_MetodoPago_new__customized) START*/

        MetodoPagoEN metodoPagoEN = null;

        int oid;

        //Initialized MetodoPagoEN
        metodoPagoEN = new MetodoPagoEN ();

        if (p_usuario != null) {
                metodoPagoEN.Usuario = new PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN ();
                metodoPagoEN.Usuario.Email = p_usuario;
        }

        metodoPagoEN.Tipo = p_tipo;

        metodoPagoEN.Valido = p_valido;

        //Call to MetodoPagoRepository

        oid = _IMetodoPagoRepository.New_ (metodoPagoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
