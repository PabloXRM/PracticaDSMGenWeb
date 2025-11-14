
using System;
using System.Text;
using System.Collections.Generic;
using PracticaDSMGen.ApplicationCore.Exceptions;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


/*PROTECTED REGION ID(usingPracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Estanteria_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
public partial class EstanteriaCEN
{
public void Modify (int p_Estanteria_OID, string p_descripcion, string p_valoracion, int p_visitas)
{
        /*PROTECTED REGION ID(PracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Estanteria_modify_customized) START*/

        EstanteriaEN estanteriaEN = null;

        //Initialized EstanteriaEN
        estanteriaEN = new EstanteriaEN ();
        estanteriaEN.Id = p_Estanteria_OID;
        estanteriaEN.Descripcion = p_descripcion;
        estanteriaEN.Valoracion = p_valoracion;
        estanteriaEN.Visitas = p_visitas;
        //Call to EstanteriaRepository

        _IEstanteriaRepository.Modify (estanteriaEN);

        /*PROTECTED REGION END*/
}
}
}
