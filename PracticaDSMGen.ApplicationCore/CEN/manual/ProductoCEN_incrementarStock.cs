
using System;
using System.Text;
using System.Collections.Generic;
using PracticaDSMGen.ApplicationCore.Exceptions;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


/*PROTECTED REGION ID(usingPracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Producto_incrementarStock) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
public partial class ProductoCEN
{
public void IncrementarStock (int p_oid, int p_cantidad)
{
        /*PROTECTED REGION ID(PracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Producto_incrementarStock) ENABLED START*/

        ProductoEN en = _IProductoRepository.ReadOID (p_oid);

        en.Stock += p_cantidad;

        _IProductoRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
