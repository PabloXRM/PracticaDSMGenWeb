
using System;
// Definición clase FacturaEN
namespace PracticaDSMGen.ApplicationCore.EN.PracticaDSM
{
public partial class FacturaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo pedido
 */
private PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN pedido;



/**
 *	Atributo numero
 */
private string numero;



/**
 *	Atributo importeTotal
 */
private decimal importeTotal;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual string Numero {
        get { return numero; } set { numero = value;  }
}



public virtual decimal ImporteTotal {
        get { return importeTotal; } set { importeTotal = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public FacturaEN()
{
}



public FacturaEN(int id, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN pedido, string numero, decimal importeTotal, Nullable<DateTime> fecha
                 )
{
        this.init (Id, pedido, numero, importeTotal, fecha);
}


public FacturaEN(FacturaEN factura)
{
        this.init (factura.Id, factura.Pedido, factura.Numero, factura.ImporteTotal, factura.Fecha);
}

private void init (int id
                   , PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN pedido, string numero, decimal importeTotal, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Pedido = pedido;

        this.Numero = numero;

        this.ImporteTotal = importeTotal;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FacturaEN t = obj as FacturaEN;
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
