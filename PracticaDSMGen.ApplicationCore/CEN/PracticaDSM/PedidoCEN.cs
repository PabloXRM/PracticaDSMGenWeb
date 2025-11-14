

using System;
using System.Text;
using System.Collections.Generic;

using PracticaDSMGen.ApplicationCore.Exceptions;

using PracticaDSMGen.ApplicationCore.EN.PracticaDSM;
using PracticaDSMGen.ApplicationCore.IRepository.PracticaDSM;


namespace PracticaDSMGen.ApplicationCore.CEN.PracticaDSM
{
/*
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoRepository _IPedidoRepository;

public PedidoCEN(IPedidoRepository _IPedidoRepository)
{
        this._IPedidoRepository = _IPedidoRepository;
}

public IPedidoRepository get_IPedidoRepository ()
{
        return this._IPedidoRepository;
}

public void Modify (int p_Pedido_OID, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.CarritoEnum p_carrito, string p_numero, Nullable<DateTime> p_fecha, decimal p_totalPrecio, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstadoPedidoEnum p_estadoPedido)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Id = p_Pedido_OID;
        pedidoEN.Carrito = p_carrito;
        pedidoEN.Numero = p_numero;
        pedidoEN.Fecha = p_fecha;
        pedidoEN.TotalPrecio = p_totalPrecio;
        pedidoEN.EstadoPedido = p_estadoPedido;
        //Call to PedidoRepository

        _IPedidoRepository.Modify (pedidoEN);
}

public void Destroy (int id
                     )
{
        _IPedidoRepository.Destroy (id);
}

public PedidoEN ReadOID (int id
                         )
{
        PedidoEN pedidoEN = null;

        pedidoEN = _IPedidoRepository.ReadOID (id);
        return pedidoEN;
}

public System.Collections.Generic.IList<PedidoEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PedidoEN> list = null;

        list = _IPedidoRepository.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN> DamePedidosPorProducto (int ? p_idProducto)
{
        return _IPedidoRepository.DamePedidosPorProducto (p_idProducto);
}
}
}
