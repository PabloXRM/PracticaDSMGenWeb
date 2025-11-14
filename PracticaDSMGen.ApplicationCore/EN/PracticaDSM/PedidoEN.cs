
using System;
// Definición clase PedidoEN
namespace PracticaDSMGen.ApplicationCore.EN.PracticaDSM
{
public partial class PedidoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo usuario
 */
private PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN usuario;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.LineaPedidoEN> lineaPedido;



/**
 *	Atributo factura
 */
private PracticaDSMGen.ApplicationCore.EN.PracticaDSM.FacturaEN factura;



/**
 *	Atributo metodoPago
 */
private PracticaDSMGen.ApplicationCore.EN.PracticaDSM.MetodoPagoEN metodoPago;



/**
 *	Atributo carrito
 */
private PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.CarritoEnum carrito;



/**
 *	Atributo numero
 */
private string numero;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo totalPrecio
 */
private decimal totalPrecio;



/**
 *	Atributo estadoPedido
 */
private PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstadoPedidoEnum estadoPedido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.EN.PracticaDSM.FacturaEN Factura {
        get { return factura; } set { factura = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.EN.PracticaDSM.MetodoPagoEN MetodoPago {
        get { return metodoPago; } set { metodoPago = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.CarritoEnum Carrito {
        get { return carrito; } set { carrito = value;  }
}



public virtual string Numero {
        get { return numero; } set { numero = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual decimal TotalPrecio {
        get { return totalPrecio; } set { totalPrecio = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstadoPedidoEnum EstadoPedido {
        get { return estadoPedido; } set { estadoPedido = value;  }
}





public PedidoEN()
{
        lineaPedido = new System.Collections.Generic.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.LineaPedidoEN>();
}



public PedidoEN(int id, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN usuario, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.LineaPedidoEN> lineaPedido, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.FacturaEN factura, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.MetodoPagoEN metodoPago, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.CarritoEnum carrito, string numero, Nullable<DateTime> fecha, decimal totalPrecio, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstadoPedidoEnum estadoPedido
                )
{
        this.init (Id, usuario, lineaPedido, factura, metodoPago, carrito, numero, fecha, totalPrecio, estadoPedido);
}


public PedidoEN(PedidoEN pedido)
{
        this.init (pedido.Id, pedido.Usuario, pedido.LineaPedido, pedido.Factura, pedido.MetodoPago, pedido.Carrito, pedido.Numero, pedido.Fecha, pedido.TotalPrecio, pedido.EstadoPedido);
}

private void init (int id
                   , PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN usuario, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.LineaPedidoEN> lineaPedido, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.FacturaEN factura, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.MetodoPagoEN metodoPago, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.CarritoEnum carrito, string numero, Nullable<DateTime> fecha, decimal totalPrecio, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstadoPedidoEnum estadoPedido)
{
        this.Id = id;


        this.Usuario = usuario;

        this.LineaPedido = lineaPedido;

        this.Factura = factura;

        this.MetodoPago = metodoPago;

        this.Carrito = carrito;

        this.Numero = numero;

        this.Fecha = fecha;

        this.TotalPrecio = totalPrecio;

        this.EstadoPedido = estadoPedido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PedidoEN t = obj as PedidoEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
