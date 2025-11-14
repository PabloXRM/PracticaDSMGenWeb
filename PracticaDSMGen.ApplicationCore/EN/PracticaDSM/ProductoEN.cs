
using System;
// Definición clase ProductoEN
namespace PracticaDSMGen.ApplicationCore.EN.PracticaDSM
{
public partial class ProductoEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo reseña
 */
private System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN> reseña;



/**
 *	Atributo estanteria
 */
private System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> estanteria;



/**
 *	Atributo lineaPedido
 */
private System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.LineaPedidoEN> lineaPedido;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo precio
 */
private decimal precio;



/**
 *	Atributo stock
 */
private int stock;



/**
 *	Atributo formato
 */
private PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.FormatoEnum formato;



/**
 *	Atributo estilo
 */
private PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstiloEnum estilo;



/**
 *	Atributo fotos
 */
private string fotos;



/**
 *	Atributo artista
 */
private string artista;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN> Reseña {
        get { return reseña; } set { reseña = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> Estanteria {
        get { return estanteria; } set { estanteria = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.LineaPedidoEN> LineaPedido {
        get { return lineaPedido; } set { lineaPedido = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual decimal Precio {
        get { return precio; } set { precio = value;  }
}



public virtual int Stock {
        get { return stock; } set { stock = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.FormatoEnum Formato {
        get { return formato; } set { formato = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstiloEnum Estilo {
        get { return estilo; } set { estilo = value;  }
}



public virtual string Fotos {
        get { return fotos; } set { fotos = value;  }
}



public virtual string Artista {
        get { return artista; } set { artista = value;  }
}





public ProductoEN()
{
        reseña = new System.Collections.Generic.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN>();
        estanteria = new System.Collections.Generic.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN>();
        lineaPedido = new System.Collections.Generic.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.LineaPedidoEN>();
}



public ProductoEN(int id, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN> reseña, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> estanteria, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.LineaPedidoEN> lineaPedido, string descripcion, decimal precio, int stock, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.FormatoEnum formato, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstiloEnum estilo, string fotos, string artista
                  )
{
        this.init (Id, reseña, estanteria, lineaPedido, descripcion, precio, stock, formato, estilo, fotos, artista);
}


public ProductoEN(ProductoEN producto)
{
        this.init (producto.Id, producto.Reseña, producto.Estanteria, producto.LineaPedido, producto.Descripcion, producto.Precio, producto.Stock, producto.Formato, producto.Estilo, producto.Fotos, producto.Artista);
}

private void init (int id
                   , System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN> reseña, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> estanteria, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.LineaPedidoEN> lineaPedido, string descripcion, decimal precio, int stock, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.FormatoEnum formato, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.EstiloEnum estilo, string fotos, string artista)
{
        this.Id = id;


        this.Reseña = reseña;

        this.Estanteria = estanteria;

        this.LineaPedido = lineaPedido;

        this.Descripcion = descripcion;

        this.Precio = precio;

        this.Stock = stock;

        this.Formato = formato;

        this.Estilo = estilo;

        this.Fotos = fotos;

        this.Artista = artista;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ProductoEN t = obj as ProductoEN;
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
