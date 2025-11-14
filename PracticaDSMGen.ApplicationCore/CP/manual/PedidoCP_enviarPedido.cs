
using System;
using System.Text;

using System.Collections.Generic;
using PracticaDSMGen.ApplicationCore.Exceptions;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;
using PracticaDSMGen.ApplicationCore.CEN.PracticaDSM;



/*PROTECTED REGION ID(usingPracticaDSMGen.ApplicationCore.CP.PracticaDSM_Pedido_enviarPedido) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGen.ApplicationCore.CP.PracticaDSM
{
public partial class PedidoCP : GenericBasicCP
{
public void EnviarPedido (int p_oid)
{
        /*PROTECTED REGION ID(PracticaDSMGen.ApplicationCore.CP.PracticaDSM_Pedido_enviarPedido) ENABLED START*/

        PedidoCEN pedidoCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                pedidoCEN = new  PedidoCEN (CPSession.UnitRepo.PedidoRepository);



                ProductoCEN productoCEN = new ProductoCEN (CPSession.UnitRepo.ProductoRepository);

                PedidoEN pedidoEN = pedidoCEN.ReadOID (p_oid);

                foreach (LineaPedidoEN linea in pedidoEN.LineaPedido) {
                        ProductoEN productoEN = linea.Producto;
                        productoCEN.DecrementarStock (productoEN.Id, linea.Cantidad);
                }

                pedidoEN.EstadoPedido = Enumerated.PracticaDSM.EstadoPedidoEnum.enviado;

                pedidoCEN.get_IPedidoRepository ().ModifyDefault (pedidoEN);


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


        /*PROTECTED REGION END*/
}
}
}
