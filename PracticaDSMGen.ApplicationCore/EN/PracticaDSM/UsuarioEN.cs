
using System;
// Definición clase UsuarioEN
namespace PracticaDSMGen.ApplicationCore.EN.PracticaDSM
{
public partial class UsuarioEN
{
/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo pedido
 */
private System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN> pedido;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo perfil
 */
private PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PerfilEN perfil;



/**
 *	Atributo estanteria
 */
private System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> estanteria;



/**
 *	Atributo reseña
 */
private System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN> reseña;



/**
 *	Atributo notificacion
 */
private System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.NotificacionEN> notificacion;



/**
 *	Atributo metodoPago
 */
private System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.MetodoPagoEN> metodoPago;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo fechaNacimiento
 */
private Nullable<DateTime> fechaNacimiento;



/**
 *	Atributo codPostal
 */
private int codPostal;



/**
 *	Atributo pass
 */
private String pass;






public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN> Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PerfilEN Perfil {
        get { return perfil; } set { perfil = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> Estanteria {
        get { return estanteria; } set { estanteria = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN> Reseña {
        get { return reseña; } set { reseña = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.NotificacionEN> Notificacion {
        get { return notificacion; } set { notificacion = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.MetodoPagoEN> MetodoPago {
        get { return metodoPago; } set { metodoPago = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual Nullable<DateTime> FechaNacimiento {
        get { return fechaNacimiento; } set { fechaNacimiento = value;  }
}



public virtual int CodPostal {
        get { return codPostal; } set { codPostal = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}





public UsuarioEN()
{
        pedido = new System.Collections.Generic.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN>();
        estanteria = new System.Collections.Generic.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN>();
        reseña = new System.Collections.Generic.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN>();
        notificacion = new System.Collections.Generic.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.NotificacionEN>();
        metodoPago = new System.Collections.Generic.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.MetodoPagoEN>();
}



public UsuarioEN(string email, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN> pedido, string nombre, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PerfilEN perfil, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> estanteria, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN> reseña, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.NotificacionEN> notificacion, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.MetodoPagoEN> metodoPago, string direccion, Nullable<DateTime> fechaNacimiento, int codPostal, String pass
                 )
{
        this.init (Email, pedido, nombre, perfil, estanteria, reseña, notificacion, metodoPago, direccion, fechaNacimiento, codPostal, pass);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (usuario.Email, usuario.Pedido, usuario.Nombre, usuario.Perfil, usuario.Estanteria, usuario.Reseña, usuario.Notificacion, usuario.MetodoPago, usuario.Direccion, usuario.FechaNacimiento, usuario.CodPostal, usuario.Pass);
}

private void init (string email
                   , System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PedidoEN> pedido, string nombre, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.PerfilEN perfil, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.EstanteriaEN> estanteria, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ReseñaEN> reseña, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.NotificacionEN> notificacion, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.MetodoPagoEN> metodoPago, string direccion, Nullable<DateTime> fechaNacimiento, int codPostal, String pass)
{
        this.Email = email;


        this.Pedido = pedido;

        this.Nombre = nombre;

        this.Perfil = perfil;

        this.Estanteria = estanteria;

        this.Reseña = reseña;

        this.Notificacion = notificacion;

        this.MetodoPago = metodoPago;

        this.Direccion = direccion;

        this.FechaNacimiento = fechaNacimiento;

        this.CodPostal = codPostal;

        this.Pass = pass;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
