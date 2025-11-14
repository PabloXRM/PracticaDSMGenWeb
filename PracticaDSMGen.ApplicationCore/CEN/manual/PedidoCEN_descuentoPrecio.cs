
using System;
using System.Text;
using System.Collections.Generic;
using PracticaDSMGen.ApplicationCore.Exceptions;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


/*PROTECTED REGION ID(usingPracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Pedido_descuentoPrecio) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
public partial class PedidoCEN
{
public void DescuentoPrecio (int p_oid, decimal p_descuento)
{
        /*PROTECTED REGION ID(PracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Pedido_descuentoPrecio) ENABLED START*/

        PedidoEN en = _IPedidoRepository.ReadOID (p_oid);

        if (en == null)
                throw new ModelException ("Pedido no encontrado: " + p_oid);

        if (p_descuento < 0 || p_descuento > 100)
                throw new ModelException ("El descuento debe estar entre 0 y 100");

        decimal factorDescuento = 1 - (p_descuento / 100);
        en.TotalPrecio = en.TotalPrecio * factorDescuento;

        _IPedidoRepository.ModifyDefault (en);

        /*PROTECTED REGION END*/
}
}
}
