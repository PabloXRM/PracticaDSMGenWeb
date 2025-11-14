
using System;
// Definición clase LineaPedidoEN
namespace PracticaDSMGen.ApplicationCore.EN.PracticaDSM
{
public partial class LineaPedidoEN
{
/**
 *	Atributo num
 */
private int num;



/**
 *	Atributo pedido
 */
private PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN pedido;



/**
 *	Atributo cantidad
 */
private int cantidad;



/**
 *	Atributo producto
 */
private PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN producto;



/**
 *	Atributo precio
 */
private decimal precio;






public virtual int Num {
        get { return num; } set { num = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}



public virtual decimal Precio {
        get { return precio; } set { precio = value;  }
}





public LineaPedidoEN()
{
}



public LineaPedidoEN(int num, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN pedido, int cantidad, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN producto, decimal precio
                     )
{
        this.init (Num, pedido, cantidad, producto, precio);
}


public LineaPedidoEN(LineaPedidoEN lineaPedido)
{
        this.init (lineaPedido.Num, lineaPedido.Pedido, lineaPedido.Cantidad, lineaPedido.Producto, lineaPedido.Precio);
}

private void init (int num
                   , PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN pedido, int cantidad, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN producto, decimal precio)
{
        this.Num = num;


        this.Pedido = pedido;

        this.Cantidad = cantidad;

        this.Producto = producto;

        this.Precio = precio;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LineaPedidoEN t = obj as LineaPedidoEN;
        if (t == null)
                return false;
        if (Num.Equals (t.Num))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Num.GetHashCode ();
        return hash;
}
}
}
