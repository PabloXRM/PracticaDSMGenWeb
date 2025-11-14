
using System;
using System.Text;
using System.Collections.Generic;
using PracticaDSMGen.ApplicationCore.Exceptions;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


/*PROTECTED REGION ID(usingPracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Estanteria_alternarVisibilidad) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
public partial class EstanteriaCEN
{
public void AlternarVisibilidad (int p_oid, bool p_visibilidad)
{
        /*PROTECTED REGION ID(PracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Estanteria_alternarVisibilidad) ENABLED START*/

        EstanteriaEN en = _IEstanteriaRepository.ReadOID (p_oid);

        if (en == null)
                throw new ModelException ("Estanteria no encontrada: " + p_oid);

        en.Visible = p_visibilidad;

        _IEstanteriaRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
