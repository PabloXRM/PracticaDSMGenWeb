
using System;
// Definición clase NotificacionEN
namespace PracticaDSMGen.ApplicationCore.EN.PracticaDSM
{
public partial class NotificacionEN
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
 *	Atributo tipo
 */
private PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TipoNotificacionEnum tipo;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo fotos
 */
private string fotos;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TipoNotificacionEnum Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Fotos {
        get { return fotos; } set { fotos = value;  }
}





public NotificacionEN()
{
}



public NotificacionEN(int id, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN usuario, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TipoNotificacionEnum tipo, Nullable<DateTime> fecha, string titulo, string descripcion, string fotos
                      )
{
        this.init (Id, usuario, tipo, fecha, titulo, descripcion, fotos);
}


public NotificacionEN(NotificacionEN notificacion)
{
        this.init (notificacion.Id, notificacion.Usuario, notificacion.Tipo, notificacion.Fecha, notificacion.Titulo, notificacion.Descripcion, notificacion.Fotos);
}

private void init (int id
                   , PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN usuario, PracticaDSMGen.ApplicationCore.Enumerated.PracticaDSM.TipoNotificacionEnum tipo, Nullable<DateTime> fecha, string titulo, string descripcion, string fotos)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Tipo = tipo;

        this.Fecha = fecha;

        this.Titulo = titulo;

        this.Descripcion = descripcion;

        this.Fotos = fotos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        NotificacionEN t = obj as NotificacionEN;
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
