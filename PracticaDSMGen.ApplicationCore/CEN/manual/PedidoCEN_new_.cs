
using System;
using System.Text;
using System.Collections.Generic;
using PracticaDSMGen.ApplicationCore.Exceptions;
using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


/*PROTECTED REGION ID(usingPracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Pedido_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
public partial class PedidoCEN
{
public int New_ (string p_usuario, int p_metodoPago, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.CarritoEnum p_carrito, string p_numero, Nullable<DateTime> p_fecha, decimal p_totalPrecio)
{
        /*PROTECTED REGION ID(PracticaDSMGen.ApplicationCore.CEN.PracticaDSM_Pedido_new__customized) ENABLED START*/

        PedidoEN pedidoEN = null;

        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();

        if (p_usuario != null) {
                pedidoEN.Usuario = new PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN ();
                pedidoEN.Usuario.Email = p_usuario;
        }


        if (p_metodoPago != -1) {
                pedidoEN.MetodoPago = new PracticaDSMGen.ApplicationCore.EN.PracticaDSM.MetodoPagoEN ();
                pedidoEN.MetodoPago.Id = p_metodoPago;
        }

        pedidoEN.Carrito = p_carrito;

        pedidoEN.Numero = p_numero;

        pedidoEN.Fecha = p_fecha;

        pedidoEN.TotalPrecio = p_totalPrecio;

        pedidoEN.EstadoPedido = Enumerated.PracticaDSM.EstadoPedidoEnum.enProceso;

        //Call to PedidoRepository

        oid = _IPedidoRepository.New_ (pedidoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
