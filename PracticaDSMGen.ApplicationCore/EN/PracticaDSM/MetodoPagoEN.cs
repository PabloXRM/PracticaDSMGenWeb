
using System;
// Definición clase MetodoPagoEN
namespace PracticaDSMGen.ApplicationCore.EN.PracticaDSM
{
public partial class MetodoPagoEN
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
 *	Atributo pedido
 */
private System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN> pedido;



/**
 *	Atributo tipo
 */
private PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TipoPagoEnum tipo;



/**
 *	Atributo valido
 */
private bool valido;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TipoPagoEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual bool Valido {
        get { return valido; } set { valido = value;  }
}





public MetodoPagoEN()
{
        pedido = new System.Collections.Generic.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN>();
}



public MetodoPagoEN(int id, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN usuario, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN> pedido, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TipoPagoEnum tipo, bool valido
                    )
{
        this.init (Id, usuario, pedido, tipo, valido);
}


public MetodoPagoEN(MetodoPagoEN metodoPago)
{
        this.init (metodoPago.Id, metodoPago.Usuario, metodoPago.Pedido, metodoPago.Tipo, metodoPago.Valido);
}

private void init (int id
                   , PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN usuario, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN> pedido, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TipoPagoEnum tipo, bool valido)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Pedido = pedido;

        this.Tipo = tipo;

        this.Valido = valido;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MetodoPagoEN t = obj as MetodoPagoEN;
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
