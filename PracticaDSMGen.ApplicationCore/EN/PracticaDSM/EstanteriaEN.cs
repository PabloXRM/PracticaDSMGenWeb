
using System;
// Definición clase EstanteriaEN
namespace PracticaDSMGen.ApplicationCore.EN.PracticaDSM
{
public partial class EstanteriaEN
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
private System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN> producto;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo valoracion
 */
private string valoracion;



/**
 *	Atributo visitas
 */
private int visitas;



/**
 *	Atributo visible
 */
private bool visible;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN> Producto {
        get { return producto; } set { producto = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual string Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual int Visitas {
        get { return visitas; } set { visitas = value;  }
}



public virtual bool Visible {
        get { return visible; } set { visible = value;  }
}





public EstanteriaEN()
{
        producto = new System.Collections.Generic.List<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN>();
}



public EstanteriaEN(int id, PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN usuario, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN> producto, string descripcion, string valoracion, int visitas, bool visible
                    )
{
        this.init (Id, usuario, producto, descripcion, valoracion, visitas, visible);
}


public EstanteriaEN(EstanteriaEN estanteria)
{
        this.init (estanteria.Id, estanteria.Usuario, estanteria.Producto, estanteria.Descripcion, estanteria.Valoracion, estanteria.Visitas, estanteria.Visible);
}

private void init (int id
                   , PracticaDSMGen.ApplicationCore.EN.PracticaDSM.UsuarioEN usuario, System.Collections.Generic.IList<PracticaDSMGen.ApplicationCore.EN.PracticaDSM.ProductoEN> producto, string descripcion, string valoracion, int visitas, bool visible)
{
        this.Id = id;


        this.Usuario = usuario;

        this.Producto = producto;

        this.Descripcion = descripcion;

        this.Valoracion = valoracion;

        this.Visitas = visitas;

        this.Visible = visible;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EstanteriaEN t = obj as EstanteriaEN;
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
