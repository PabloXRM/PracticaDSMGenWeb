
using System;
using System.Text;

using System.Collections.Generic;
using PracticaDSMGen.ApplicationCore.Exceptions;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;



/*PROTECTED REGION ID(usingPracticaDSMGen.ApplicationCore.CP.PracticaDSM_LineaPedido_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGen.ApplicationCore.CP.PracticaDSM
{
public partial class LineaPedidoCP : GenericBasicCP
{
public PracticaDSMGen.ApplicationCore.EN.PracticaDSM.LineaPedidoEN New_ (int p_pedido, int p_cantidad, int p_producto, decimal p_precio)
{
        /*PROTECTED REGION ID(PracticaDSMGen.ApplicationCore.CP.PracticaDSM_LineaPedido_new_) ENABLED START*/

        LineaPedidoCEN lineaPedidoCEN = null;

        PracticaDSMGen.ApplicationCore.EN.PracticaDSM.LineaPedidoEN result = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                lineaPedidoCEN = new  LineaPedidoCEN (CPSession.UnitRepo.LineaPedidoRepository);

                PedidoCEN pedidoCEN = new PedidoCEN (CPSession.UnitRepo.PedidoRepository);



                int oid;
                //Initialized LineaPedidoEN
                LineaPedidoEN lineaPedidoEN;
                lineaPedidoEN = new LineaPedidoEN ();

                if (p_pedido != -1) {
                        lineaPedidoEN.Pedido = new PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN ();
                        lineaPedidoEN.Pedido.Id = p_pedido;
                }

                lineaPedidoEN.Cantidad = p_cantidad;


                if (p_producto != -1) {
                        lineaPedidoEN.Producto = new PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN ();
                        lineaPedidoEN.Producto.Id = p_producto;
                }

                lineaPedidoEN.Precio = p_precio;

                PedidoEN pedidoEN = pedidoCEN.ReadOID (p_pedido);

                pedidoEN.TotalPrecio += lineaPedidoEN.Cantidad * lineaPedidoEN.Precio;

                pedidoCEN.get_IPedidoRepository ().ModifyDefault (pedidoEN);

                oid = lineaPedidoCEN.get_ILineaPedidoRepository ().New_ (lineaPedidoEN);

                result = lineaPedidoCEN.get_ILineaPedidoRepository ().ReadOIDDefault (oid);



                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
