
using System;
// Definición clase ReseñaEN
namespace PracticaDSMGen.ApplicationCore.EN.PracticaDSM
{
public partial class ReseñaEN
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
 *	Atributo producto
 */
private PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN producto;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo nota
 */
private int nota;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN Producto {
        get { return producto; } set { producto = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual int Nota {
        get { return nota; } set { nota = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}





public ReseñaEN()
{
}



public ReseñaEN(int id, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN usuario, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN producto, string descripcion, int nota, Nullable<DateTime> fecha
                )
{
        this.init (Id, usuario, producto, descripcion, nota, fecha);
}


public ReseñaEN(ReseñaEN reseña)
{
        this.init (reseña.Id, reseña.Usuario, reseña.Producto, reseña.Descripcion, reseña.Nota, reseña.Fecha);
}

private void init (int id
                   , PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN usuario, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN producto, string descripcion, int nota, Nullable<DateTime> fecha)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Producto = producto;

        this.Descripcion = descripcion;

        this.Nota = nota;

        this.Fecha = fecha;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ReseñaEN t = obj as ReseñaEN;
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
